
namespace AutomapperTest;

public class AutoMapperTests
{
    [Fact]
    public void ShouldMapChildToNull()
    {
        var mapper = config.CreateMapper();
        var parent = new Parent();
        var dto = new ParentDto { Child = new ChildDto() };

        var mapped = mapper.Map(parent, dto);

        Assert.Null(mapped.Child);
    }

    readonly MapperConfiguration config = new(cfg =>
    {
        cfg.CreateMap<Child, ChildDto>().ReverseMap();
        cfg.CreateMap<Parent, ParentDto>().ReverseMap();
    });
}

public class Parent
{
    public Child? Child { get; set; } = null;
}

public class ParentDto
{
    public ChildDto? Child { get; set; }
}

public class Child { }

public class ChildDto { }