using System.Collections.Generic;
using System.Linq;
using Limitless.Data.Infrastructure;
using Limitless.Data.Repositories;
using Limitless.Model;

namespace Limitless.Service
{ 
 public interface IMembershipService
{
    IEnumerable<Membership> GetMemberships(string name = null);
    Membership GetMembership(int id);
    void CreateMembership(Membership Membership);
    void SaveMembership();
}
public class Membershipervice : IMembershipService
{
    private readonly IMembershipRepository MembershipRepository;
    private readonly IUnitOfWork unitOfWork;

    public Membershipervice(IMembershipRepository MembershipRepository, IUnitOfWork unitOfWork)
    {
        this.MembershipRepository = MembershipRepository;
        this.unitOfWork = unitOfWork;
    }

    #region IMembershipervice Members

    public IEnumerable<Membership> GetMemberships(string name = null)
    {
        if (string.IsNullOrEmpty(name))
            return MembershipRepository.GetAll();
        else
            return MembershipRepository.GetAll();
    }

    public Membership GetMembership(int id)
    {
        var Membership = MembershipRepository.GetById(id);
        return Membership;
    }


    public void CreateMembership(Membership Membership)
    {
        MembershipRepository.Add(Membership);
    }

    public void SaveMembership()
    {
        unitOfWork.Commit();
    }

    #endregion
}
}