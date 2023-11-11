namespace WebApplication1.Models
{
    //тест взят тут
    //https://xn--j1ahfl.xn--p1ai/library/psihologicheskie_testimetodiki_anketi_220930.html

    public class CreateOneTest
    {
        static public void CreateTest(UserContext context)
        {
            CreateTest test = new CreateTest();
            test.Name = "Определение мотивации";
            test.Description = "Анкета для определения школьной мотивации (разработана Н.Г.Лускановой).";
            test.NumberQuestions = 10;
            test.NumberChoiceInQuestion = 3;

            test.ResultText = "За каждый первый ответ – 3 балла, за промежуточный – 1 балл, последний – 0 баллов." +
               Environment.NewLine + "Максимальная оценка – 30 баллов.Чем выше балл, тем выше школьная мотивация." +
               Environment.NewLine + "25 – 30 баллов: сформировано отношение к себе как к школьнику, высокая учебная активность." +
               Environment.NewLine + "20 – 24 балла: отношение к себе как к школьнику практически сформировано(средняя норма мотивации)." +
               Environment.NewLine + "15 – 19 баллов: положительное отношение к школе, но школа привлекает больше внеучебными сторонами(внешняя мотивация)." +
                Environment.NewLine + "10 – 14 баллов: отношение к себе как к школьнику не сформировано(низкий уровень мотивации)." +
                Environment.NewLine + "Ниже 10 баллов: негативное отношение к школе(школьная дезадаптация).";

            Question question1 = new Question() { Number = 1, Title = "Тебе нравится в школе?" };
            Answer answer1 = new Answer() { Text = "да", PointsNumber = 3, Question = question1 };
            Answer answer2 = new Answer() { Text = "нет", PointsNumber = 1, Question = question1 };
            Answer answer3 = new Answer() { Text = "не очень", PointsNumber = 0, Question = question1 };
            question1.Answers.Add(answer1);
            question1.Answers.Add(answer2);
            question1.Answers.Add(answer3);
            question1.Test = test;


            Question question2 = new Question() { Number = 2, Title = "Утром ты всегда с радостью идёшь в школу или тебе часто хочется остаться дома?" };
            Answer answer21 = new Answer() { Text = "иду с радостью", PointsNumber = 3, Question = question2 };
            Answer answer22 = new Answer() { Text = "бывает по-разному", PointsNumber = 1, Question = question2 };
            Answer answer23 = new Answer() { Text = "чаще хочется остаться дома", PointsNumber = 0, Question = question2 };
            question2.Answers.Add(answer21);
            question2.Answers.Add(answer22);
            question2.Answers.Add(answer23);
            question2.Test = test;


            Question question3 = new Question()
            {
                Number = 3,
                Title = "Если бы учитель сказал, что завтра в школу не обязательно приходить всем ученикам, ты пошёл бы или остался дома?",
                Answers = new List<Answer>()
                {
                new Answer() { Text = "иду с радостью", PointsNumber = 3},
                new Answer() { Text = "бывает по-разному", PointsNumber = 1},
                new Answer() { Text = "чаще хочется остаться дома", PointsNumber = 0}
                },
                Test = test
            };

            Question question4 = new Question()
            {
                Number = 4,
                Title = "Тебе нравится, когда отменяются какие-нибудь уроки?",
                Answers = new List<Answer>()
                {
                new Answer() { Text = "не нравится", PointsNumber = 3},
                new Answer() { Text = "бывает по-разному", PointsNumber = 1},
                new Answer() { Text = "нравится", PointsNumber = 0}
                },
                Test = test
            };

            Question question5 = new Question()
            {
                Number = 5,
                Title = "Ты хотел бы, чтобы тебе не задавали никаких домашних заданий?",
                Answers = new List<Answer>()
                {
                new Answer() { Text = "не хотел бы", PointsNumber = 3},
                new Answer() { Text = "не знаю", PointsNumber = 1},
                new Answer() { Text = "хотел бы", PointsNumber = 0}
                },
                Test = test
            };


            Question question6 = new Question()
            {
                Number = 6,
                Title = "Ты хотел бы, чтобы в школе остались одни перемены?",
                Answers = new List<Answer>()
                {
                new Answer() { Text = "нет", PointsNumber = 3},
                new Answer() { Text = "не знаю", PointsNumber = 1},
                new Answer() { Text = "хотел бы", PointsNumber = 0}
                },
                Test = test
            };

            Question question7 = new Question()
            {
                Number = 7,
                Title = "Ты часто рассказываешь о школе своим родителям и друзьям?",
                Answers = new List<Answer>()
                {
                new Answer() { Text = "часто", PointsNumber = 3},
                new Answer() { Text = "редко", PointsNumber = 1},
                new Answer() { Text = "не рассказываю", PointsNumber = 0}
                },
                Test = test
            };


            Question question8 = new Question()
            {
                Number = 8,
                Title = "Ты хотел бы, чтобы у тебя был другой, менее строгий учитель?",
                Answers = new List<Answer>()
                {
                new Answer() { Text = "мне нравится наш учитель", PointsNumber = 3},
                new Answer() { Text = "точно не знаю", PointsNumber = 1},
                new Answer() { Text = "хотел бы", PointsNumber = 0}
                },
                Test = test
            };

            Question question9 = new Question()
            {
                Number = 9,
                Title = "У тебя в классе много друзей?",
                Answers = new List<Answer>()
                {
                new Answer() { Text = "много", PointsNumber = 3},
                new Answer() { Text = "мало", PointsNumber = 1},
                new Answer() { Text = "нет друзей", PointsNumber = 0}
                },
                Test = test
            };

            Question question10 = new Question()
            {
                Number = 10,
                Title = "Тебе нравятся твои одноклассники?",
                Answers = new List<Answer>()
                {
                new Answer() { Text = "нравятся", PointsNumber = 3},
                new Answer() { Text = "не очень", PointsNumber = 1},
                new Answer() { Text = "не нравится", PointsNumber = 0}
                },
                Test = test
            };

            test.Questions.AddRange(new List<Question> { question1, question2, question3, question4,question5,
            question6,question7,question8,question9,question10});

            test.MaxSum = 30;
            context.CreateTests.Add(test);
            context.SaveChanges();
        }
    }
}
