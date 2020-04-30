run:
	dotnet run --project=Todo.Api

migrate:
	cd Todo.Infra && dotnet ef migrations add ${version}

update:
	cd Todo.Infra && dotnet ef database update
