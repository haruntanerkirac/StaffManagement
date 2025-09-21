var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.StaffManagement_WebAPI>("staffmanagement-webapi");

builder.Build().Run();
