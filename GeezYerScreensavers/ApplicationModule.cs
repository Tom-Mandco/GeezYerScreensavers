﻿namespace GeezYerScreensavers
{
    using Ninject.Modules;
    using NLog;
    using Classes;
    using Interfaces;
    using System;
    using System.Configuration;

    class ApplicationModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ILog>().ToMethod(x =>
            {
                var scope = x.Request.ParentRequest.Service.FullName;
                var log = (ILog)LogManager.GetLogger(scope, typeof(Log));
                return log;
            });
            Bind<IApp>().To<App>();
            Bind<IFileSaver>().To<FileSaver>();
            Bind<IFileFinder>().To<FileFinder>();
            Bind<ICleanseFilePaths>().To<FilePathCleanser>();
            Bind<IOrganizeFiles>().To<FileOrganizer>();
            Bind<ICallYoDumbAssWhateverYoWant>().To<WhatYoDumbAssWannaBeCalled>();
        }
    }
}
