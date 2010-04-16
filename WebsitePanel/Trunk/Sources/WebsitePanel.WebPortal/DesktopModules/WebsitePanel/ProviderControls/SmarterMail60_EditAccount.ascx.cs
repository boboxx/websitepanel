// Copyright (c) 2010, SMB SAAS Systems Inc.
// All rights reserved.
//
// Redistribution and use in source and binary forms, with or without modification,
// are permitted provided that the following conditions are met:
//
// - Redistributions of source code must  retain  the  above copyright notice, this
//   list of conditions and the following disclaimer.
//
// - Redistributions in binary form  must  reproduce the  above  copyright  notice,
//   this list of conditions  and  the  following  disclaimer in  the documentation
//   and/or other materials provided with the distribution.
//
// - Neither  the  name  of  the  SMB SAAS Systems Inc.  nor   the   names  of  its
//   contributors may be used to endorse or  promote  products  derived  from  this
//   software without specific prior written permission.
//
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND
// ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING,  BUT  NOT  LIMITED TO, THE IMPLIED
// WARRANTIES  OF  MERCHANTABILITY   AND  FITNESS  FOR  A  PARTICULAR  PURPOSE  ARE
// DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR
// ANY DIRECT, INDIRECT, INCIDENTAL,  SPECIAL,  EXEMPLARY, OR CONSEQUENTIAL DAMAGES
// (INCLUDING, BUT NOT LIMITED TO,  PROCUREMENT  OF  SUBSTITUTE  GOODS OR SERVICES;
// LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION)  HOWEVER  CAUSED AND ON
// ANY  THEORY  OF  LIABILITY,  WHETHER  IN  CONTRACT,  STRICT  LIABILITY,  OR TORT
// (INCLUDING NEGLIGENCE OR OTHERWISE)  ARISING  IN  ANY WAY OUT OF THE USE OF THIS
// SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

﻿using System;
using WebsitePanel.Providers.Mail;

namespace WebsitePanel.Portal.ProviderControls
{
    public partial class SmarterMail60_EditAccount : WebsitePanelControlBase, IMailEditAccountControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            passwordRow.Visible = (PanelRequest.ItemID > 0);
        }

        public void BindItem(MailAccount item)
        {
            txtFirstName.Text = item.FirstName;
            txtLastName.Text = item.LastName;
            txtSignature.Text = item.Signature;
            chkResponderEnabled.Checked = item.ResponderEnabled;
            txtReplyTo.Text = item.ReplyTo;
            txtSubject.Text = item.ResponderSubject;
            txtMessage.Text = item.ResponderMessage;
            txtForward.Text = item.ForwardingAddresses != null ? String.Join("; ", item.ForwardingAddresses) : "";
            chkDeleteOnForward.Checked = item.DeleteOnForward;
            cbDomainAdmin.Visible = item.IsDomainAdminEnabled;
            cbDomainAdmin.Checked = item.IsDomainAdmin;
        }

        public void SaveItem(MailAccount item)
        {
            item.FirstName = txtFirstName.Text;
            item.LastName = txtLastName.Text;
            item.Signature = txtSignature.Text;
            item.ResponderEnabled = chkResponderEnabled.Checked;
            item.ReplyTo = txtReplyTo.Text;
            item.ResponderSubject = txtSubject.Text;
            item.ResponderMessage = txtMessage.Text;
            item.ForwardingAddresses = Utils.ParseDelimitedString(txtForward.Text, ';', ' ', ',');
            item.DeleteOnForward = chkDeleteOnForward.Checked;
            item.ChangePassword = cbChangePassword.Checked;
            item.ChangePassword = cbChangePassword.Checked;
            item.IsDomainAdmin = cbDomainAdmin.Checked;
        }
    }
}