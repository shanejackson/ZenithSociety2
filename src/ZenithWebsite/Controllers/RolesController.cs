﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using ZenithWebsite.Models.RoleViewModels;

namespace ZenithWebsite.Controllers {
    //[Authorize(Roles = "Admin")]
    public class RolesController : Controller {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RolesController(RoleManager<IdentityRole> roleManager) {
            _roleManager = roleManager;
        }

        // GET: Roles
        public ActionResult Index() {
            // Get all the roles 
            var roles = _roleManager.Roles.ToList();

            // Convert the roles to something we can use and edit 
            List<IdentityRoleViewModel> rolesView = new List<IdentityRoleViewModel>();
            foreach (IdentityRole r in roles) {
                rolesView.Add(getViewModelFromModel(r));
            }

            // Display
            return View(rolesView);
        }

        // GET: Roles/Details/5
        public async Task<ActionResult> Details(string id) {
            var role = await _roleManager.FindByIdAsync(id);
            if (role == null) {
                return NotFound();
            }
            var roleView = getViewModelFromModel(role);
            return View(roleView);
        }

        // GET: Roles/Create
        public ActionResult Create() {
            return View();
        }

        // POST: Roles/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(IdentityRoleViewModel roleView) {
            if (ModelState.IsValid) {
                // Convert view model to a model  
                var newRole = new IdentityRole();
                newRole.Name = roleView.RoleName;
                var newRoleResult = await _roleManager.CreateAsync(newRole);

                if (newRoleResult.Succeeded) {
                    return RedirectToAction("Index");
                } else {
                    ModelState.AddModelError(string.Empty, "Failed to create role");
                }
            }

            // If here, then an error occured. 
            return View(roleView);
        }

        // GET: Roles/Edit/5
        public async Task<ActionResult> Edit(string id) {
            var role = await _roleManager.FindByIdAsync(id);
            if (role == null) {
                return NotFound();
            }
            var roleView = getViewModelFromModel(role);
            return View(roleView);
        }

        // POST: Roles/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind("RoleId,RoleName")] IdentityRoleViewModel roleView) {
            if (ModelState.IsValid) {
                var role = await _roleManager.FindByIdAsync(roleView.RoleId);
                role.Name = roleView.RoleName;
                var result = await _roleManager.UpdateAsync(role);

                // Fast exit if editing role 'admin'
                if (role.NormalizedName == "ADMIN") {
                    ModelState.AddModelError(string.Empty, "Admin role cannot be edited");
                    return View(roleView);
                }

                if (result.Succeeded) {
                    return RedirectToAction("Index");
                } else {
                    AddErrors(result);
                }
            }

            return View(roleView);
        }

        // GET: Roles/Delete/5
        public async Task<ActionResult> Delete(string id) {
            var role = await _roleManager.FindByIdAsync(id);
            if (role == null) {
                return NotFound();
            }
            var roleView = getViewModelFromModel(role);
            return View(roleView);
        }

        // POST: Roles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id, IdentityRoleViewModel viewModel) {
            var role = await _roleManager.FindByIdAsync(id);

            if (role == null) {
                ModelState.AddModelError(String.Empty, "Role not found.");
                return View(viewModel);
            }

            if (role.NormalizedName == "ADMIN") {
                ModelState.AddModelError(String.Empty, "Role 'Admin' cannot be deleted.");
                return View(viewModel);
            }

            var result = await _roleManager.DeleteAsync(role);

            if (!result.Succeeded) {
                AddErrors(result);
                return View(viewModel);
            } else {
                return RedirectToAction("Index");
            }
        }



        #region Helpers

        private IdentityRoleViewModel getViewModelFromModel(IdentityRole role) {
            return new IdentityRoleViewModel() {
                RoleId = role.Id,
                RoleName = role.Name,
                NormalizedName = role.NormalizedName
            };
        }

        private void AddErrors(IdentityResult result) {
            foreach (var error in result.Errors) {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        #endregion
    }
}