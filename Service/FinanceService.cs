using SmartFin.Db;
using SmartFin.DTO;
using SmartFin.Entities;

namespace SmartFin.Service
{

    public class FinanceService
    {

        private readonly IRepository<User> userRepository;
        private readonly IRepository<Category> categoryRepository;

        private readonly IRepository<Expense> expenseRepository;

        private readonly IRepository<Goal> goalRepository;

        private readonly IRepository<Recomendation> recomendationRepository;



        public FinanceService()
        {
            userRepository = new PostrgresRepository<User>();
            categoryRepository = new PostrgresRepository<Category>();
            expenseRepository = new PostrgresRepository<Expense>();
            goalRepository = new PostrgresRepository<Goal>();
            recomendationRepository = new PostrgresRepository<Recomendation>();

        }
        public async Task AddIncomeAsync(Guid userId, decimal income)
        {
            if (income <= 0)
                throw new ArgumentException("Income has to be more than zero ");
            var user = await userRepository.GetAsync(userId);
            if (user == null)
                throw new ArgumentException("User not found");

            user.income = income;
            await userRepository.UpdateAsync(user);

        }
        public async Task AddUserCategoryAsync(Guid userId, CreateCategoryDTO category)
        {
            using (var context = new SmartFinDbContext())
            {

                var user = context.Users.FirstOrDefault(x => x.guid == userId);
                if (user == null)
                    throw new ArgumentException("User not found");

                if (user.Categorys.Any(c => c.name == category.name))
                    throw new ArgumentException("User already has this category");
                Category newCategory = new Category
                {
                    guid = Guid.NewGuid(),
                    name = category.name,
                    planSumm = category.planSumm,
                    userId = user.guid,
                    user = user
                };

                await context.AddAsync(newCategory);
                context.SaveChanges();
            }
        }
        public async Task<List<Category>> GetAllCategoriesByUserIdAsync(Guid userId)
        {
            var user = userRepository.GetAsync(userId);
            if (user == null)
                throw new ArgumentException("User not found");

            var categories = (await categoryRepository.GetAllAsync()).Where(x => x.userId == userId).ToList();
            return categories;
        }
        public async Task UpdateUserCategoryAsync(Guid categoryId, UpdateCategoryDTO category)
        {

            var existCategory = await categoryRepository.GetAsync(categoryId);
            if (existCategory == null)
                throw new ArgumentException("Category not found");
            existCategory.name = category.name;
            existCategory.planSumm = category.planSumm;
            await categoryRepository.UpdateAsync(existCategory);

        }
        public async Task DeleteUserCategoryAsyn(Guid categoryId)
        {
            await categoryRepository.DeleteAsync(categoryId);

        }


        public async Task AddGoalAsync(Guid userId, CreateGoalDto goal)
        {
            var user = await userRepository.GetAsync(userId);
            if (user == null)
                throw new ArgumentException("User not found");

            decimal expenseSum = user.Expenses.Sum(x => x.sum);
            if (goal.sum > (user.income - expenseSum) * (int)((goal.endOfPeriod - goal.startOfPeriod).Days / 30.436875))
            {
                throw new Exception("Goal can't be reached");
            }
            var newGoal = new Goal
            {
                guid = new Guid(),
                nameOfGoal = goal.nameOfGoal,
                startOfPeriod = goal.startOfPeriod,
                endOfPeriod = goal.endOfPeriod,
                sum = goal.sum
            };


        }

        public async Task AddUserExpenseAsync(User user, Expense expense, Category category)
        {

            user.Expenses.Add(expense);
            await userRepository.UpdateAsync(user);
            expense.user = user;
            expense.category = category;
            await expenseRepository.UpdateAsync(expense);
        }


    }
}