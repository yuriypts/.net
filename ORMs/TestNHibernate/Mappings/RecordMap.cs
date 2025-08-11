using FluentNHibernate.Mapping;
using TestNHibernate.DBModels;

namespace TestNHibernate.Mappings;

public class RecordMap : ClassMap<Record>
{
    public RecordMap()
    {
        Table("Record");
        Id(x => x.Id).GeneratedBy.Identity().Column("Id");
        Map(x => x.SolidId).Column("SolidId").Unique().Not.Nullable();
        Map(x => x.Name).Column("Name").Nullable();
    }

}

