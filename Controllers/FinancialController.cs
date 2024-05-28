using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SmartFin.Db;
using SmartFin.DTO;
using SmartFin.Entities;
using SmartFin.Service;

namespace SmartFin.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Financial : ControllerBase
    {
        private readonly FinanceService _financeService;

        public Financial(FinanceService _financeService)
        {
            this._financeService = _financeService;
        }

        /// <summary>
        /// Добавить доход пользователю.
        /// </summary>
        /// <param name="userId">Айди</param>
        /// <param name="income">Доход</param>
        /// <returns></returns>
        [HttpPost("user/{userId}/income")]
        public async Task<IActionResult> AddIncome(Guid userId, decimal income)
        {
            try
            {
                await _financeService.AddIncomeAsync(userId, income);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Добавить категорию пользователя
        /// </summary>
        /// <param name="userId"> Айди пользователя</param>
        /// <param name="category"> информация о категории</param>
        /// <returns></returns>
        [HttpPost("user/{userId}/category")]

        public async Task<IActionResult> AddUserCategoryAsync(Guid userId, [FromBody] CreateCategoryDTO category)
        {

            try
            {
                await _financeService.AddUserCategoryAsync(userId, category);
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Получить все категории пользователя
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet("user/{userId}/category")]

        public async Task<IActionResult> GetUserCategoriesAsync(Guid userId)
        {
            try
            {
                var categories = (await _financeService.GetAllCategoriesByUserIdAsync(userId)).Select(x => x.AsDto()).ToList();

                return Ok(categories);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Обновить категорию пользователя
        /// </summary>
        /// <param name="userId">айди пользователя</param>
        /// <param name="category">Данные о категории</param>
        /// <returns></returns>
        [HttpPut("user/{userId}/category")]
        public async Task<IActionResult> UpdateUserCategoryAsync(Guid gategoryId, [FromBody] UpdateCategoryDTO category)
        {
            try
            {
                await _financeService.UpdateUserCategoryAsync(gategoryId, category);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Удалить категорию пользователя
        /// </summary>
        /// <param name="CategoryId">Guid категории</param>
        /// <returns></returns>
        [HttpDelete("user/category/{CategoryId}")]

        public async Task<IActionResult> DeleteUserCategory(Guid CategoryId)
        {
            try
            {
                await _financeService.DeleteUserCategoryAsyn(CategoryId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("user/{userId}/goal")]
        public async Task<IActionResult> AddUserGoal(Guid userId, [FromBody]CreateGoalDto goal){
                try
            {
                await _financeService.AddUserGoalAsync(userId, goal);
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        /// <summary>
        /// Удалить цель пользователя
        /// </summary>
        /// <param name="GoalId"></param>
        /// <returns></returns>
        [HttpDelete("user/goal/{GoalId}")]
        public async Task<IActionResult> DeleteUserGoal(Guid GoalId)
        {
            try
            {
                await _financeService.DeleteUserGoalAsyn(GoalId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
