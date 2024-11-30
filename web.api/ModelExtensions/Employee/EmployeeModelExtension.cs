using employee.contract.Models.Employee;
using employee.web.api.Entities;

namespace employee.web.api.ModelExtensions.Employee
{
	public static class EmployeeModelExtension
	{
		public static EmployeeData ToDTO(this EmployeeEntity employeeEntity) => new()
		{
			Id = employeeEntity.Id,
			FirstName = employeeEntity.FirstName,
			LastName = employeeEntity.LastName,
			Department = employeeEntity.Department,
			Designation = employeeEntity.Designation,
			Email = employeeEntity.Email,
			PhoneNumber = employeeEntity?.PhoneNumber,
		};


		public static EmployeeEntity ToEntity(this EmployeeData employeeData) => new()
		{
			Id = employeeData.Id,
			Department = employeeData?.Department,
			Designation = employeeData?.Designation,
			Email = employeeData?.Email,
			FirstName = employeeData?.FirstName,
			LastName= employeeData?.LastName,
			PhoneNumber= employeeData?.PhoneNumber
		};

		public static EmployeeEntity ToEntity(this AddEmployeeRequest request) => new EmployeeEntity()
		{
			Department = request?.Department,
			Designation = request?.Designation,
			Email = request?.Email,
			FirstName = request?.FirstName,
			LastName = request?.LastName,
			PhoneNumber = request?.PhoneNumber
		};

		public static List<EmployeeData> ToListDTO(this List<EmployeeEntity> entities)
		{
			return entities.Select(e => new EmployeeData()
			{
				Id = e.Id,
				Department = e.Department,
				Designation= e.Designation,
				Email= e.Email,
				PhoneNumber= e.PhoneNumber,
				FirstName= e.FirstName,
				LastName = e.LastName,
			}).ToList();
		}
	}
}
