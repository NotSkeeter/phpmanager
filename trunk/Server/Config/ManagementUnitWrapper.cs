﻿//-----------------------------------------------------------------------
// <copyright>
// Copyright (C) Ruslan Yakushev for the PHP Manager for IIS project.
//
// This file is subject to the terms and conditions of the Microsoft Public License (MS-PL).
// See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL for more details.
// </copyright>
//-----------------------------------------------------------------------

using Microsoft.Web.Administration;
using Microsoft.Web.Management.Server;

namespace Web.Management.PHP.Config
{

    internal sealed class ManagementUnitWrapper : ConfigurationWrapper
    {
        private ManagementUnit _managementUnit;

        public ManagementUnitWrapper(ManagementUnit managementUnit)
        {
            _managementUnit = managementUnit;
        }

        public override void CommitChanges()
        {
            _managementUnit.Update();
        }

        public override Configuration GetAppHostConfiguration()
        {
            return _managementUnit.ServerManager.GetApplicationHostConfiguration();
        }

        public override DefaultDocument.DefaultDocumentSection GetDefaultDocumentSection()
        {
            ManagementConfiguration config = _managementUnit.Configuration;
            return (DefaultDocument.DefaultDocumentSection)config.GetSection("system.webServer/defaultDocument", typeof(DefaultDocument.DefaultDocumentSection));
        }

        public override Handlers.HandlersSection GetHandlersSection()
        {
            ManagementConfiguration config = _managementUnit.Configuration;
            return (Handlers.HandlersSection)config.GetSection("system.webServer/handlers", typeof(Handlers.HandlersSection));
        }

        public override bool IsServerConfigurationPath()
        {
            return (_managementUnit.ConfigurationPath.PathType == ConfigurationPathType.Server);
        }

    }
}