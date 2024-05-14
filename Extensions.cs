using SmartFin.DTO;
using SmartFin.Entities;

namespace SmartFin
{

    public static class Extensions
    {

        public static UserDTO AsDto(this User user) {
         return new UserDTO(user.guid, user.number, user.income, user.goal,
         user.Expenses.ToList(),  user.Recomendations.ToList(), user.Categorys.ToList());
        }

         public static CategoryDTO AsDto(this Category category) {
            return new CategoryDTO(category.guid, category.name, category.planSumm, category.factSumm,
             category.user, category.expenses);
         }
         public static ExpenseDTO AsDto(this Expense expense) {
            return new ExpenseDTO(expense.guid, expense.sum, expense.dateOfExpense, 
            expense.name, expense.category, expense.user);
         }

        public static GoalDto AsDto(this Goal goal) {
            return new GoalDto(goal.guid, goal.startOfPeriod, goal.endOfPeriod, goal.nameOfGoal, goal.sum,
             goal.payment, goal.user, goal.recomendations);
        }
        public static RecomendationDTO AsDto(this Recomendation recomendation) {

            return new RecomendationDTO(recomendation.guid, recomendation.message,
            recomendation.dateOfRecommendation, recomendation.goal, recomendation.user);
        }
    }
}