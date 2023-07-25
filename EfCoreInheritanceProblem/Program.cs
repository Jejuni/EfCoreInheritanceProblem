using EfCoreInheritanceProblem;
using Microsoft.EntityFrameworkCore;

await using (var ctx = new MyDbContext())
{
    await ctx.Database.EnsureDeletedAsync();
    await ctx.Database.EnsureCreatedAsync();
}

await using (var ctx2 = new MyDbContext())
{
    ctx2.ChildOnes.Add(new ChildOne { Number = 2 });

    await ctx2.SaveChangesAsync();
}

await using (var ctx3 = new MyDbContext())
{
    var childOnes = await ctx3.ChildOnes.ToListAsync();
    var childTwos = await ctx3.ChildTwos.ToListAsync();
    // NEXT LINE CAUSES EXCEPTION
    var parents = await ctx3.Parents.ToListAsync();
}