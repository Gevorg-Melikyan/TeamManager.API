namespace TeamManager.Application.Permissions
{
    public static class Permission
    {
        public static class Task
        {
            public const string Create = "Perm.Task.Create";
            public const string View = "Perm.Task.View";
            public const string Edit = "Perm.Task.Edit";
            public const string Delete = "Perm.Task.Delete";
        }

        public static class Project
        {
            public const string Create = "Perm.Project.Create";
            public const string View = "Perm.Project.View";
            public const string Edit = "Perm.Project.Edit";
            public const string Delete = "Perm.Project.Delete";
        }

        public static class ProjectMember
        {
            public const string Create = "Perm.ProjectMember.Create";
            public const string View = "Perm.ProjectMember.View";
            public const string Edit = "Perm.ProjectMember.Edit";
            public const string Delete = "Perm.ProjectMember.Delete";
        }


        public static class Users
        {
            public const string View = "Perm.Users.View";
            public const string Create = "Perm.Users.Create";
            public const string Edit = "Perm.Users.Edit";
            public const string Delete = "Perm.Users.Delete";
        }

        public static class Roles
        {
            public const string View = "Perm.Roles.View";
            public const string Create = "Perm.Roles.Create";
            public const string Edit = "Perm.Roles.Edit";
            public const string Delete = "Perm.Roles.Delete";
        }
    }
}
