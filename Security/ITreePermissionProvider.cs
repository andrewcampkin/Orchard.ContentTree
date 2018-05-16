namespace Orchard.ContentTree.Security {
    using ContentManagement;
    using Core.Contents;
    using Orchard.Security;

    public interface ITreePermissionProvider : IDependency {
        bool Editable(IContent content);
    }

    public class DefaultTreePermissionProvider : ITreePermissionProvider {
        private readonly IAuthorizer _authorizer;
        public DefaultTreePermissionProvider(IAuthorizer authorizer) {
            _authorizer = authorizer;
        }

        public bool Editable(IContent content) {
            return _authorizer.Authorize(Permissions.EditContent, content);
        }
    }
}