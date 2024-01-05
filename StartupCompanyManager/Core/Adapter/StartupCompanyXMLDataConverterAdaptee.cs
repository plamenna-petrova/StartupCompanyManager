using StartupCompanyManager.Constants;
using StartupCompanyManager.Models;
using StartupCompanyManager.Models.Composite.Component;
using StartupCompanyManager.Models.Singleton;
using System.Xml.Linq;

namespace StartupCompanyManager.Core.Adapter
{
    public class StartupCompanyXMLDataConverterAdaptee
    {
        private const string XML_FILE_RELATIVE_PATH = "../../../StartupCompanyManager.xml";

        private readonly StartupCompany startupCompany = StartupCompany.StartupCompanyInstance;

        public void ConvertStartupCompanyDataToXML()
        {
            XDocument startupCompanyXDocument = new();

            XElement startupCompanyRootXElement = new(nameof(StartupCompany));

            List<XElement> startupCompanyXElements = new()
            {
                new(nameof(startupCompany.Name), startupCompany.Name),
                new(nameof(startupCompany.Capital), startupCompany.Capital),
                new(nameof(startupCompany.YearOfEstablishment), startupCompany.YearOfEstablishment),
                new(nameof(startupCompany.Email), startupCompany.Email),
                new(nameof(startupCompany.Address), startupCompany.Address),
                new(nameof(startupCompany.PhoneNumber), startupCompany.PhoneNumber)
            };

            startupCompanyRootXElement.Add(startupCompanyXElements);

            List<XElement> investorsXElements = new();

            if (startupCompany.Investors.Any())
            {
                foreach (var investor in startupCompany.Investors)
                {
                    XElement investorXElement = new(nameof(Investor));

                    List<XElement> investorXElements = new()
                    {
                        new XElement(nameof(investor.Name), investor.Name),
                        new XElement(nameof(investor.Funds), investor.Funds)
                    };

                    investorXElement.Add(investorXElements);
                    investorsXElements.Add(investorXElement);
                }
            }

            List<XElement> departmentsXElements = new();

            if (startupCompany.Departments.Any())
            {
                foreach (var department in startupCompany.Departments)
                {
                    XElement departmentXElement = new(nameof(Department));

                    List<XElement> departmentXElements = new()
                    {
                        new XElement(nameof(department.Name), department.Name),
                        new XElement(nameof(department.YearOfEstablishment), department.YearOfEstablishment)
                    };

                    departmentXElement.Add(departmentXElements);

                    if (department.HeadOfDepartment != null)
                    {
                        departmentXElement.Add(CreateEmployeesHierarchyXElements(department.HeadOfDepartment));
                    }

                    departmentsXElements.Add(departmentXElement);
                }
            }

            if (investorsXElements.Any())
            {
                startupCompanyRootXElement.Add(investorsXElements);
            }

            if (departmentsXElements.Any())
            {
                startupCompanyRootXElement.Add(departmentsXElements);
            }

            startupCompanyXDocument.Add(startupCompanyRootXElement);

            startupCompanyXDocument.Save(XML_FILE_RELATIVE_PATH);
        }

        private XElement CreateEmployeesHierarchyXElements(Employee superiorEmployee)
        {
            XElement superiorEmployeeXElement = new(superiorEmployee.GetType().Name);

            List<XElement> superiorEmployeeXElements = new()
            {
                new(nameof(superiorEmployee.FirstName), superiorEmployee.FirstName),
                new(nameof(superiorEmployee.LastName), superiorEmployee.LastName),
                new(nameof(superiorEmployee.Position), superiorEmployee.Position),
                new(nameof(superiorEmployee.MonthlySalary), superiorEmployee.MonthlySalary),
                new(nameof(superiorEmployee.YearsOfWorkExperience), superiorEmployee.YearsOfWorkExperience),
                new(nameof(superiorEmployee.BirthDate), superiorEmployee.BirthDate.ToString(GlobalConstants.DATE_TIME_VALUE_FORMAT)),
                new(nameof(superiorEmployee.Rating), superiorEmployee.Rating.ToString())
            };

            superiorEmployeeXElement.Add(superiorEmployeeXElements);

            if (superiorEmployee.Employees != null)
            {
                foreach (var subordinateEmployee in superiorEmployee.Employees)
                {
                    XElement subordinateEmployeeXElement = CreateEmployeesHierarchyXElements(subordinateEmployee);
                    superiorEmployeeXElement.Add(subordinateEmployeeXElement);
                }
            }

            return superiorEmployeeXElement;
        }
    }
}
