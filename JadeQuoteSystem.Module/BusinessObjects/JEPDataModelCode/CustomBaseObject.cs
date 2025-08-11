
using DevExpress.ExpressApp;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.PermissionPolicy;
using DevExpress.Xpo;
using Microsoft.Identity.Client;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JadeQuoteSystem.Module.BusinessObjects.JEPDataModelCode
{
    [NonPersistent]
    public abstract class CustomBaseObject : XPCustomObject

    {
        public CustomBaseObject(Session session) : base(session)
        {

        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
            CreatedOn = DateTime.Now;
            CreatedBy = GetCurrentUser();

        }
        protected override void OnDeleting()
        {
            DeletedOn = DateTime.Now;
            DeletedBy = GetCurrentUser();

            base.OnDeleting();
        }

        private PermissionPolicyUser GetCurrentUser()
        {
            if (SecuritySystem.CurrentUser != null && SecuritySystem.CurrentUser is PermissionPolicyUser)
                return Session.GetObjectByKey<PermissionPolicyUser>(SecuritySystem.CurrentUserId);

            return null;
        }

        [Key(true), Persistent(nameof(Oid))]
        private int _Oid;
        [VisibleInDetailView(false)]
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        [PersistentAlias(nameof(_Oid))]
        public int Oid { get => _Oid; }

        private DateTime _CreatedOn;
        [NonCloneable]
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        [VisibleInDetailView(false)]
        public DateTime CreatedOn
        {
            get { return _CreatedOn; }
            set { SetPropertyValue<DateTime>("CreatedOn", ref _CreatedOn, value); }
        }

        private PermissionPolicyUser _CreatedBy;
        [NonCloneable]
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        [VisibleInDetailView(false)]
        public PermissionPolicyUser CreatedBy
        {
            get { return _CreatedBy; }
            set { SetPropertyValue<PermissionPolicyUser>("CreatedBy", ref _CreatedBy, value); }
        }

        private DateTime _LastModifiedOn;
        [NonCloneable]
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        [VisibleInDetailView(false)]
        public DateTime LastModifiedOn
        {
            get { return _LastModifiedOn; }
            set { SetPropertyValue<DateTime>("LastModifiedOn", ref _LastModifiedOn, value); }
        }

        private PermissionPolicyUser _LastModifiedBy;
        [NonCloneable]
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        [VisibleInDetailView(false)]
        public PermissionPolicyUser LastModifiedBy
        {
            get { return _LastModifiedBy; }
            set { SetPropertyValue<PermissionPolicyUser>("LastModifiedBy", ref _LastModifiedBy, value); }
        }

        private DateTime _DeletedOn;
        [NonCloneable]
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        [VisibleInDetailView(false)]
        public DateTime DeletedOn
        {
            get { return _DeletedOn; }
            set { SetPropertyValue<DateTime>("DeletedOn", ref _DeletedOn, value); }
        }

        private PermissionPolicyUser _DeletedBy;
        [NonCloneable]
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        [VisibleInDetailView(false)]
        public PermissionPolicyUser DeletedBy
        {
            get { return _DeletedBy; }
            set { SetPropertyValue<PermissionPolicyUser>("DeletedBy", ref _DeletedBy, value); }
        }
    }
}
