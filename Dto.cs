using System.ComponentModel.DataAnnotations;
using SmartFin.Entities;

namespace SmartFin.DTO{

    public record UserDTO(Guid guid, string number, decimal income, Goal? goal,
     List<Expense>?Expenses, List<Recomendation>?Recomendations, List<Category>?Categorys );
     public record CreateUserDto([Required]string number, decimal income);

     public record UpdateUserDto([Required]string number, decimal income);

     public record CategoryDTO( Guid guid, string name, decimal planSumm, decimal factSumm,
      User user, List<Expense>? expenses);

      public record CreateCategoryDTO([Required]string name, decimal planSumm);


      public record UpdateCategoryDTO([Required]string name, decimal planSumm);

    public record ExpenseDTO(Guid guid, decimal sum, DateTime dateOfExpense, string name, Category Category, User user);
    public record CreateExpenseDTO([Required]decimal sum, DateTime dateOfExpense, string name, Guid CategoryId, Guid userId);

    public record UpdateExpenseRecord([Required]decimal sum, DateTime dateOfExpense, string name);

    public record GoalDto(  Guid guid, DateTime startOfPeriod, DateTime endOfPeriod, string nameOfGoal, decimal sum, decimal payment, 
                                User user, List<Recomendation>? recomendations);
    public record CreateGoalDto(DateTime startOfPeriod, DateTime endOfPeriod, [Required]string nameOfGoal, decimal sum, Guid UserId);
    public record UpdateGoalDTO(DateTime startOfPeriod, DateTime endOfPeriod, [Required]string nameOfGoal, decimal sum, decimal payment);
    public record RecomendationDTO(Guid guid, string message, DateTime dateOfRecommendation, Goal goal, User user);

    public record CreateRecomendationDTO(string message, DateTime dateOfRecommendation, [Required]Guid goalId, List<Guid>categoriesId);

    public record UpdateRecomendationDTO(string message, DateTime dateOfRecommendation);



}