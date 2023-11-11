namespace WebApplication1.Models
{
    //тест взят тут
    //https://nsportal.ru/shkola/raznoe/library/2017/09/21/sbornik-metodik-diagnostik-anket

    public class CreateSecondTest
    {
        static public void CreateTest(UserContext context)
        {
            CreateTest test = new CreateTest();
            test.Name = "Самоконтроль в общении";
            test.Description = "Самоконтроль в общении (тест М. Снайдера)";
            test.NumberQuestions = 10;
            test.NumberChoiceInQuestion = 2;
            test.ResultText = "Интерпретация: " +
                "\n0 - 3 балла – у вас низкий коммуникативный контроль.Вы принципиальны и прямолинейны и гордитесь этим.Не считаете нужным «подстраиваться» под кого – либо или подо что-либо.В общении вы искренни и надёжны.Многие вас любят за это.Однако некоторые считают вас «неудобной» и «недипломатичной» личностью.Это может стать помехой при работе в коллективе, особенно в женском, где, как известно, личные отношения значат очень много." +
                "\n4 - 6 баллов – у вас   средний коммуникативный контроль.Вы достаточно искренни и вместе с тем «аккуратны в выражениях». Обычно проблем в общении у вас не возникает." +
                "\n7 - 10 баллов – у вас высокий коммуникативный контроль.Вы согласны с фразой «Весь мир – театр, а люди в нём – актёры». Вы гибко реагируете на изменения ситуации, хорошо чувствуете впечатление, которое производите на окружающих, любите иногда «подыграть». Вы прекрасно знаете, где и как нужно себя вести. Профессиональное общение не является для вас проблемой, но вот когда дело касается глубоких отношений, искренности и самораскрытия, то вы чувствуете, что вам неуютно без привычных ролей и масок.";

            Question question1 = new Question()
            {
                Number = 1,
                Title = "Мне кажется трудным искусство подражать повадкам других людей",
                Answers = new List<Answer>()
                {
                new Answer() { Text = "Верно", PointsNumber = 0},
                new Answer() { Text = "Неверно", PointsNumber = 1},
                },
                Test = test
            };

            Question question2 = new Question()
            {
                Number = 2,
                Title = "Я бы, пожалуй, мог свалять дурака, чтобы привлечь внимание или позабавить окружающих",
                Answers = new List<Answer>()
                {
                new Answer() { Text = "Верно", PointsNumber = 1},
                new Answer() { Text = "Неверно", PointsNumber = 0},
                },
                Test = test
            };


            Question question3 = new Question()
            {
                Number = 3,
                Title = "Из меня мог бы выйти неплохой актёр",
                Answers = new List<Answer>()
                {
                new Answer() { Text = "Верно", PointsNumber = 1},
                new Answer() { Text = "Неверно", PointsNumber = 0},
                },
                Test = test
            };

            Question question4 = new Question()
            {
                Number = 4,
                Title = "Другим людям иногда кажется, что я переживаю что – то более глубокое, чем это есть на самом деле",
                Answers = new List<Answer>()
                {
                new Answer() { Text = "Верно", PointsNumber = 1},
                new Answer() { Text = "Неверно", PointsNumber = 0},
                },
                Test = test
            };

            Question question5 = new Question()
            {
                Number = 5,
                Title = "В компании я редко оказываюсь в центре внимания",
                Answers = new List<Answer>()
                {
                new Answer() { Text = "Верно", PointsNumber = 0},
                new Answer() { Text = "Неверно", PointsNumber = 1},
                },
                Test = test
            };


            Question question6 = new Question()
            {
                Number = 6,
                Title = "В разных ситуациях и общении с разными людьми я часто веду себя совершенно по - разному",
                Answers = new List<Answer>()
                {
                new Answer() { Text = "Верно", PointsNumber = 1},
                new Answer() { Text = "Неверно", PointsNumber = 0},
                },
                Test = test
            };

            Question question7 = new Question()
            {
                Number = 7,
                Title = "Я могу отстаивать только то, в чём я искренне убеждён",
                Answers = new List<Answer>()
                {
                new Answer() { Text = "Верно", PointsNumber = 0},
                new Answer() { Text = "Неверно", PointsNumber = 1},
                },
                Test = test
            };


            Question question8 = new Question()
            {
                Number = 8,
                Title = "Чтобы преуспеть в делах и в отношениях с людьми, я стараюсь быть таким, каким меня ожидают увидеть",
                Answers = new List<Answer>()
                {
                new Answer() { Text = "Верно", PointsNumber = 1},
                new Answer() { Text = "Неверно", PointsNumber = 0},
                },
                Test = test
            };

            Question question9 = new Question()
            {
                Number = 9,
                Title = "Я могу быть дружелюбным с людьми, которых я не выношу.",
                Answers = new List<Answer>()
                {
                new Answer() { Text = "Верно", PointsNumber = 1},
                new Answer() { Text = "Неверно", PointsNumber = 0},
                },
                Test = test
            };

            Question question10 = new Question()
            {
                Number = 10,
                Title = "Я всегда такой, каким кажусь",
                Answers = new List<Answer>()
                {
                new Answer() { Text = "Верно", PointsNumber = 1},
                new Answer() { Text = "Неверно", PointsNumber = 0},
                },
                Test = test
            };

            test.Questions.AddRange(new List<Question> { question1, question2, question3, question4,question5,
            question6,question7,question8,question9,question10});

            test.MaxSum = 10;
            context.CreateTests.Add(test);
            context.SaveChanges();
        }
    }
}
