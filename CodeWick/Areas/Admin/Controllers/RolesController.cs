using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using CodeWick.Helpers;
using CodeWick.Models;
using CodeWick.Repository;
using CodeWick.Areas.Admin.Models;

namespace CodeWick.Areas.Admin.Controllers {
    [HandleError]
    [SessionAttribute]
    //[AdminAuthorize]
    public class RolesController : Controller {
        private readonly IRoleRepository roleRepository;
        private readonly IUserRepository userRepository;

        // If you are using Dependency Injection, you can delete the following constructor
        public RolesController() : this(new RoleRepository(), new UserRepository()) { }

        public RolesController(IRoleRepository roleRepository, IUserRepository userRepository) {
            this.roleRepository = roleRepository;
            this.userRepository = userRepository;
        }

        // GET: /Roles/_RoleUsers/RoleId
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public ActionResult _RoleUsers(Guid id) {
            return View(GetUsers(id));
        }

        [HttpPost, OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public ActionResult _RoleUsers(Guid id, List<string> available_list, List<string> relationship_list) {
            if (id != null) {
                using (CodeWickContext context = new CodeWickContext()) {
                    // Get Role
                    Role role = context.Roles.SingleOrDefault(tbl => tbl.RoleId == id);

                    // Remove users from the Role if they are in the available_list
                    if (available_list != null) {
                        foreach (string available in available_list) {
                            Guid userId = Guid.Parse(available);
                            User user = context.Users.FirstOrDefault(tbl => tbl.UserId == userId);
                            user.Roles.Remove(role);
                            context.SaveChanges();
                        }
                    }

                    // Add Users to Role if they are in the relationship_list
                    if (relationship_list != null) {
                        foreach (string relationship in relationship_list) {
                            Guid userId = Guid.Parse(relationship);
                            User user = context.Users.FirstOrDefault(tbl => tbl.UserId == userId);
                            user.Roles.Add(role);
                            context.SaveChanges();
                        }
                    }
                }
            }
            return View(GetUsers(id));
        }

        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public RoleUsers_ViewModel GetUsers(Guid id) {
            RoleUsers_ViewModel Model = new RoleUsers_ViewModel();

            if (id != null) {
                using (CodeWickContext context = new CodeWickContext()) {
                    Model.Role = context.Roles.SingleOrDefault(tbl => tbl.RoleId == id);
                    Model.UsersInRole = Model.Role.Users.ToList();
                    Model.UsersAvailable = context.Users.ToList();

                    foreach (User user in Model.UsersInRole) {
                        Model.UsersAvailable.Remove(user);
                    }
                }
            }

            return Model;
        }

        // GET: /Roles/
        public ViewResult Index() {
            return View(roleRepository.AllIncluding(role => role.Users));
        }

        // GET: /Roles/Details/5
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public ViewResult _Details(System.Guid id) {
            return View(roleRepository.Find(id));
        }

        // GET: /Roles/Create
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public ActionResult _Create() {
            return View();
        }

        // POST: /Roles/Create
        [HttpPost, OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public ActionResult _Create(Role role) {
            if (ModelState.IsValid) {
                roleRepository.InsertOrUpdate(role);
                roleRepository.Save();
                return RedirectToAction("Index");
            } else {
                return View();
            }
        }

        // GET: /Roles/Edit/5
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public ActionResult _Edit(System.Guid id) {
            return View(roleRepository.Find(id));
        }

        // POST: /Roles/Edit/5
        [HttpPost, OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public ActionResult _Edit(Role role) {
            if (ModelState.IsValid) {
                roleRepository.InsertOrUpdate(role);
                roleRepository.Save();
                return RedirectToAction("Index");
            } else {
                return View();
            }
        }

        // GET: /Roles/Delete/5
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public ActionResult _Delete(System.Guid id) {
            return View(roleRepository.Find(id));
        }

        // POST: /Roles/Delete/5
        [HttpPost, ActionName("_Delete"), OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public ActionResult _DeleteConfirmed(System.Guid id) {
            roleRepository.Delete(id);
            roleRepository.Save();

            return RedirectToAction("Index");
        }
    }
}