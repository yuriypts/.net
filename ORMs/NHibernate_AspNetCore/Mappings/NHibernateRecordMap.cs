using FluentNHibernate.Mapping;
using NHibernate_AspNetCore.DBModels;

namespace NHibernate_AspNetCore.Mappings;

public class NHibernateRecordMap : ClassMap<NHibernateRecord>
{
    public NHibernateRecordMap()
    {
        Table("NHibernateRecord");
        Id(x => x.Id).GeneratedBy.Identity().Column("Id");
        Map(x => x.SolidId).Column("SolidId").Unique().Not.Nullable();
        Map(x => x.Name).Column("Name").Nullable();
    }

}

