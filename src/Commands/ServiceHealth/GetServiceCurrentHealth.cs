﻿using System.Management.Automation;
using PnP.PowerShell.Commands.Attributes;
using PnP.PowerShell.Commands.Base;
using PnP.PowerShell.Commands.Utilities;

namespace PnP.PowerShell.Commands.ServiceHealth
{
    [Cmdlet(VerbsCommon.Get, "PnPServiceCurrentHealth")]
    [RequiredMinimalApiPermissions("https://graph.microsoft.com/ServiceHealth.Read.All")]
    public class GetServiceCurrentHealth : PnPGraphCmdlet
    {
        [Parameter(Mandatory = false)]
        public string Identity;

        protected override void ExecuteCmdlet()
        {
            if (ParameterSpecified(nameof(Identity)))
            {
                WriteObject(ServiceHealthUtility.GetServiceCurrentHealthById(this, Identity, Connection, AccessToken), false);
            }
            else
            {
                WriteObject(ServiceHealthUtility.GetServiceCurrentHealth(this, Connection, AccessToken), true);
            }
        }
    }
}