// using System;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Mvc;
// using SmartFin.Db;
// using SmartFin.DTO;
// using SmartFin.Entities;
// using SmartFin.Service;

// namespace SmartFin.Controllers
// {
//     [ApiController]
//     [Route("recomendation")]
//     public class RecomendationController : ControllerBase
//     {
//         private readonly IRepository<Recomendation> RecomendationRepository;

//         public RecomendationController()
//         {
//             this.RecomendationRepository = new PostrgresRepository<Recomendation>();
//         }

//         [HttpPost]
//         public async Task<ActionResult<Recomendation>> PostAsync(CreateRecomendationDTO entity)
//         {   
//             var recomendation = new Recomendation{
//                     guid = new Guid(),
//                     message = entity.message,
//                     dateOfRecommendation = entity.dateOfRecommendation,
//             };
//             await RecomendationRepository.CreateAsync(recomendation);
//             return CreatedAtAction(nameof(GetByIdAsync), new { recomendation.guid, entity });
//         }

//         [HttpDelete("{id}")]
//         public async Task<IActionResult> DeleteAsync(Guid id)
//         {
//             var exisitingRec = await RecomendationRepository.GetAsync(id);

//             if (exisitingRec == null){
//                 return NotFound();

//             }

//             await RecomendationRepository.DeleteAsync(exisitingRec.guid);
//                 return NoContent();
//         }

//         [HttpGet]
//         public async Task<ActionResult<IEnumerable<RecomendationDTO>>> GetAsync()
//         {
//             var users = (await RecomendationRepository.GetAllAsync()).Select(x=> x.AsDto());
//             return Ok(users);
//         }

//         [HttpGet("{id}")]
//         public async Task<ActionResult<RecomendationDTO>> GetByIdAsync(Guid id)
//         {
//             var recomendation = await RecomendationRepository.GetAsync(id);
//             if (recomendation == null)
//             {
//                 return NotFound();
//             }
//             return Ok(recomendation.AsDto());
//         }

//         [HttpPut("{id}")]
//         public async Task<IActionResult> UpdateAsync(Guid id, UpdateRecomendationDTO recomendationDTO)
//         {
//             var recomendation = await RecomendationRepository.GetAsync(id);
//             if(recomendation == null){
//                 return NotFound();
//             }
//                  recomendation.message = recomendationDTO.message;
//                     recomendation.dateOfRecommendation = recomendationDTO.dateOfRecommendation;                              
//             await RecomendationRepository.UpdateAsync(recomendation);
//             return NoContent();
//         }
//     }
// }