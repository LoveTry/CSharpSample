using System;
using System.Data.Entity;

namespace EverythingWeb.Entity
{
    public class MyMusicDbInitializer : DropCreateDatabaseAlways<MyContext>
    {
        protected override void Seed(MyContext context)
        {
            var Style1 = new MusicStyle() { StyleID = Guid.NewGuid(), StyleName = "流行" };
            var Style2 = new MusicStyle() { StyleID = Guid.NewGuid(), StyleName = "民谣" };
            context.MusicStyles.Add(Style1);
            context.MusicStyles.Add(new MusicStyle() { StyleID = Guid.NewGuid(), StyleName = "摇滚" });
            context.MusicStyles.Add(new MusicStyle() { StyleID = Guid.NewGuid(), StyleName = "爵士" });
            context.MusicStyles.Add(new MusicStyle() { StyleID = Guid.NewGuid(), StyleName = "古典" });
            context.MusicStyles.Add(Style2);

            context.Musics.Add(new Musics()
            {
                ID = Guid.NewGuid(),
                Name = "安河桥",
                Singer = "宋冬野",
                StyleID = Style1.StyleID
            });
            base.Seed(context);
        }
    }
}