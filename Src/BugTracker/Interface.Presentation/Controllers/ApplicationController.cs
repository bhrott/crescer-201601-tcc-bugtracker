﻿using BugTracker.Domain.Entity;
using BugTracker.Domain.Interface.Service;
using Interface.Presentation.Filters;
using Interface.Presentation.Models;
using Interface.Presentation.Models.Application;
using Interface.Presentation.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Interface.Presentation.Controllers
{
    public class ApplicationController : Controller
    {
        private IApplicationService applicationService;
        private IUserService userService;

        public ApplicationController()
        {
            applicationService = ApplicationServiceInjection.Create();
            userService = UserServiceInjection.Create();
        }

        [UserToken]
        [HttpGet]
        public ActionResult RegisterApp(int? id)
        {
            if (id.HasValue)
            {
                var app = applicationService.FindById((int)id);
                var model = new ApplicationModel();
                model.Id = app.IDApplication;
                model.Title = app.Title;
                model.Url = app.Url;
                model.Description = app.Description;
                model.Icon = app.Image;
                
                model.Tag = app.SpecialTag;

                return View("register-app", model);
            }

            return View("register-app");
        }
 
        [HttpPost]
        [UserToken]
        public ActionResult NewEditApp(ApplicationModel model)
        {

            var IdUser = UserSessionService.LoggedUser.IDUser;
            var user = userService.FindById(IdUser);
            String fileName = model.Icon;

            if (model.File != null)
            {
                fileName = model.File.FileName;
            }
            
            if (model.Id.HasValue)
            {
                var app = new Application(model.Id.Value, model.Title, model.Description,
                                      model.Url, true, fileName,
                                      model.Tag, IdUser, user);
                applicationService.Edit(app);
            }
            else
            {
                var app = new Application(model.Title, model.Description,
                                      model.Url, true, fileName,
                                      model.Tag, IdUser, user);
                applicationService.Add(app);
            }
            
            UploadImageService.UploadUserImage(model.File);
            return RedirectToAction("Index", "User");
        }

        [UserToken]
        [HttpGet]
        public ActionResult DeleteApp(int id)
        {
            var app = applicationService.FindById(id);
            var user = userService.FindById(app.IDUser);

            var appToDelete = new Application(app.IDApplication, app.Title, app.Description, app.Url, false, app.Image, app.SpecialTag, app.IDUser, user);
            applicationService.Edit(appToDelete);

            return RedirectToAction("Index", "User");
        }

        [UserToken]
        [HttpGet]
        public ActionResult DetailsApp(int id)
        {
            var app = applicationService.FindById(id);

            if (app.IDUser != UserSessionService.LoggedUser.IDUser)
            {
                return RedirectToAction("Index", "User");
            }

            return View("details", app);
        }
    }
}