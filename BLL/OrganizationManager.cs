using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityModels;
using Repository;

namespace BLL
{
    public class OrganizationManager
    {
        OrganizationRepository _organizationRepository=new OrganizationRepository();
        public bool Add(Organization organization)
        {
            if (organization!=null)
            {
                bool isAdded = _organizationRepository.Add(organization);
                return isAdded;
            }
            return false;
        }

        public List<Organization> GetAllOrganization()
        {
            var organizations = _organizationRepository.GetAll();
            return organizations;
        }
    }
}
