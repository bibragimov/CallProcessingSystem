using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using Domain.Entities;
using Domain.Entities.Enums;

namespace Domain.EF.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<CallSystemDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(CallSystemDbContext context)
        {
            if (!context.Set<Identity>().Any())
            {
                var identities = new List<Identity>
                {
                    new Operator
                    {
                        Avatar = "http://via.placeholder.com/500x500",
                        Email = "test@test.ru",
                        Locale = "ru",
                        Name = "Иванов Иван",
                        Password = "ANT5iwlAubGGzhtAyby8fAhE0V2ExkPNeOr2HZ0S2JPUcFmT+ma/EoyuGdKME1USNw==",
                        Role = RoleType.Operator
                    },
                    new Operator
                    {
                        Avatar = "http://via.placeholder.com/500x500",
                        Email = "test1@test.ru",
                        Locale = "ru",
                        Name = "Вадим Гурьев",
                        Password = "ANT5iwlAubGGzhtAyby8fAhE0V2ExkPNeOr2HZ0S2JPUcFmT+ma/EoyuGdKME1USNw==",
                        Role = RoleType.Operator
                    },
                    new Executor
                    {
                        Avatar = "http://via.placeholder.com/500x500",
                        Email = "test2@test.ru",
                        Locale = "ru",
                        Name = "Кулагин Кирилл",
                        Password = "ANT5iwlAubGGzhtAyby8fAhE0V2ExkPNeOr2HZ0S2JPUcFmT+ma/EoyuGdKME1USNw==",
                        Role = RoleType.Executor
                    },
                    new Operator
                    {
                        Avatar = "http://via.placeholder.com/500x500",
                        Email = "test3@test.ru",
                        Locale = "ru",
                        Name = "Лаврентьева Маргарита",
                        Password = "ANT5iwlAubGGzhtAyby8fAhE0V2ExkPNeOr2HZ0S2JPUcFmT+ma/EoyuGdKME1USNw==",
                        Role = RoleType.Operator
                    },
                    new Executor
                    {
                        Avatar = "http://via.placeholder.com/500x500",
                        Email = "test4@test.ru",
                        Locale = "ru",
                        Name = "Анисимова Наталья",
                        Password = "ANT5iwlAubGGzhtAyby8fAhE0V2ExkPNeOr2HZ0S2JPUcFmT+ma/EoyuGdKME1USNw==",
                        Role = RoleType.Executor
                    },
                    new Executor
                    {
                        Avatar = "http://via.placeholder.com/500x500",
                        Email = "test5@test.ru",
                        Locale = "ru",
                        Name = "Андреев Яков",
                        Password = "ANT5iwlAubGGzhtAyby8fAhE0V2ExkPNeOr2HZ0S2JPUcFmT+ma/EoyuGdKME1USNw==",
                        Role = RoleType.Executor
                    }
                };

                context.Set<Identity>().AddRange(identities);

                var themes = new List<RequestTheme>
                {
                    new RequestTheme
                    {
                        Title = "Оформление заказа"
                    },
                    new RequestTheme
                    {
                        Title = "Оплата заказа"
                    },
                    new RequestTheme
                    {
                        Title = "Ошибка при оформлении или оплате"
                    },
                    new RequestTheme
                    {
                        Title = "Возврат"
                    },
                    new RequestTheme
                    {
                        Title = "Обмен"
                    },
                    new RequestTheme
                    {
                        Title = "Претензия"
                    },
                    new RequestTheme
                    {
                        Title = "Другое"
                    }
                };
                context.Set<RequestTheme>().AddRange(themes);

                var requests = new List<UserRequest>
                {
                    new UserRequest
                    {
                        ComplaintMessage = "Все не работает. Раньше работало, а сейчас нет. Верните как было",
                        ExecutorId = 3,
                        OperatorId = 1,
                        Status = RequestStatusType.Registered,
                        Phone = "+79006453434",
                        ThemeId = 6,
                        UserName = "Вася Пупкин"
                    },
                    new UserRequest
                    {
                        ComplaintMessage = "Пропал интернет",
                        ExecutorId = 5,
                        OperatorId = 1,
                        Status = RequestStatusType.Performed,
                        Phone = "+79006453434",
                        ThemeId = 7,
                        UserName = "Юрий Доронин",
                        Comment = "Починилось само"
                    },
                    new UserRequest
                    {
                        ComplaintMessage = "Хочу получить бонусы, как постоянному клиенту",
                        ExecutorId = 5,
                        OperatorId = 2,
                        Status = RequestStatusType.NotPerformed,
                        Phone = "+79006453434",
                        ThemeId = 1,
                        UserName = "Леонид Королёв",
                        Comment = "Бонусы закончились"
                    }
                };

                context.Set<UserRequest>().AddRange(requests);

                context.SaveChanges();
            }
        }
    }
}