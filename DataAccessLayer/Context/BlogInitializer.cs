using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Entities.Models;

namespace DataAccessLayerSQL.Context
{
    public class BlogInitializer : DropCreateDatabaseAlways<BlogContext>
    {
        protected override void Seed(BlogContext context)
        {
            var tags = new List<Tagg>()
            {
                new Tagg(){ Id = 1, Text = "C#" },
                new Tagg(){ Id = 2, Text = ".NET" },
                new Tagg(){ Id = 3, Text = "JS" },
                new Tagg(){ Id = 4, Text = "CSS" },
                new Tagg(){ Id = 5, Text = "EF6" },
            };
            var articles = new List<Article>()
            {
                new Article()
                {
                    Id = 1, Name = "EF6", Date = DateTime.UtcNow, Text = "DbContext.OnModelCreating - метод [Эта страница относится к документации к Entity Framework 6. Последняя версия доступна в составе пакета Entity Framework NuGet. Дополнительные сведения об Entity Framework см. в разделе msdn.com/data/ef.] Этот метод вызывается, если модель для производного контекста была инициализирована, прежде чем модель была заблокирована и использована для инициализации контекста. Реализация этого метода по умолчанию не делает ничего, но его можно переопределить в производном классе и выполнить в нем дальнейшую настройку модели перед ее блокировкой. Пространство имен:  System.Data.Entity Сборка:  EntityFramework(в EntityFramework.dll)СинтаксисC#C++F#JScriptVB protected virtual void OnModelCreating( DbModelBuilder modelBuilder) Параметры modelBuilder Тип: System.Data.Entity.DbModelBuilder Построитель, который определяет модель для создаваемого контекста. ПримечанияОбычно этот метод вызывается только один раз при создании первого экземпляра производного контекста.Затем модель для этого контекста кэшируется и применяется для всех последующих экземпляров контекста в домене приложений.Это кэширование можно отключить, задав соответствующее значение свойству ModelCaching данного объекта ModelBuidler, но обратите внимание, что при этом может существенно снизиться производительность.Дополнительное управление кэшированием можно получить с помощью прямого использования классов DbModelBuilder и DbContextFactory.",
                    Tags =  new List<Tagg> { tags[4] }

                },
                new Article()
                {
                    Id = 2, Name = ".NET", Date = DateTime.UtcNow, Text = "Этот набор содержимого .NET Framework включает сведения для версий .NET Framework 4.5, 4.5.1, 4.5.2, 4.6 и 4.6.1. Чтобы скачать платформу .NET Framework, изучите раздел Установка .NET Framework. Список новых функций и изменений в .NET Framework 4.5, .NET Framework 4.6 и их вспомогательных выпусках см. в статье Новые возможности. Список поддерживаемых платформ см. в разделе Системные требования .NET Framework. .NET Framework — это платформа разработки для создания приложений для Windows, Windows Phone, Windows Server и Microsoft Azure. Она состоит из среды CLR и библиотеки классов .NET Framework, которая содержит классы, интерфейсы и типы значений, поддерживающие широкий диапазон технологий. Платформа .NET Framework предоставляет среду управляемого выполнения, возможности упрощения разработки и развертывания, а также возможности интеграции с различными языками программирования, включая Visual Basic и Visual C#.System_CAPS_ICON_note.jpg Примечание Чтобы скачать платформу .NET Framework, изучите раздел Установка .NET Framework. Общие сведения о платформе .NET Framework для пользователей и разработчиков см. в разделе Начало работы. Введение в архитектуру и основные функции платформы .NET Framework см. в обзоре.Документация .NET Framework включает подробный справочник по библиотекам классов, общие обзоры, пошаговые процедуры, а также сведения о примерах, компиляторах и средствах с интерфейсом командной строки. Найти нужную информацию поможет приведенный ниже перечень основных разделов.",
                    Tags =  new List<Tagg> { tags[4], tags[1] }

                },
                 new Article()
                {
                    Id = 3, Name = "Security Silverlight", Date = DateTime.UtcNow, Text = "Security is incorporated into the design of Silverlight. By default, Silverlight applications are hosted in a browser and run in an environment that restricts access to the user's computer. Despite the restricted execution environment, there are some security considerations when you build Silverlight applications. In addition, Silverlight 4 and later applications can be configured to run in elevated trust, which also has security implications.This topic describes how Silverlight is made secure through its restricted run environment and provides security guidance for building Silverlight applications in different scenarios.In addition, you will find many links to more information.",
                    Tags =  new List<Tagg> { tags[1] }

                 }

            };
            var reviews = new List<Review>()
            {
                new Review()
                {
                     Id=1, Authorname="Nick", Date = DateTime.UtcNow, Text = "Hello dudes. I do not know how i turned up here but this place is beautiful."
                },
                new Review()
                {
                     Id=1, Authorname="Ketty", Date = DateTime.UtcNow, Text = "Hi. I love this blog!"
                },
                new Review()
                {
                     Id=1, Authorname="Joe", Date = DateTime.UtcNow, Text = "What a disgusting site..."
                }
            };
            var answersFirstQuestion = new List<Answer>()
            {
                new Answer()
                {
                     Id = 1,
                     Text = "Yes",
                     QuestionId = 1,
                     VotesCount = 10

                },
                new Answer()
                {
                    Id = 2,
                    Text = "Sometimes",
                    QuestionId = 1,
                    VotesCount = 20

                },
                new Answer()
                {
                    Id = 3,
                    Text = "No",
                    QuestionId = 1,
                    VotesCount =30
                }

            };
            var answersSecondQuestion = new List<Answer>()
            {
                new Answer()
                {
                     Id = 4,
                     Text = "Junior",
                     QuestionId = 1,
                     VotesCount = 10

                },
                new Answer()
                {
                    Id = 5,
                    Text = "Middle",
                    QuestionId = 1,
                    VotesCount = 20

                },
                new Answer()
                {
                    Id = 6,
                    Text = "Senior",
                    QuestionId = 1,
                    VotesCount =30
                },
                new Answer()
                {
                    Id = 7,
                    Text = "Team Lead",
                    QuestionId = 1,
                    VotesCount =30
                },
                new Answer()
                {
                    Id = 8,
                    Text = "Master",
                    QuestionId = 1,
                    VotesCount =30
                }

            };
            //I insert data here
            context.Tags.AddRange(tags);
            context.Articles.AddRange(articles);
            context.Reviews.AddRange(reviews);
            context.Answers.AddRange(answersFirstQuestion);
            context.Answers.AddRange(answersSecondQuestion);
            context.SaveChanges();
        }
    }
}