using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebAPI.Models
{
    public class Stuff
    {
        [Key]
        public int SID { get; set; }
        public string EQPID { get; set; }
        public string COMPID { get; set; }
        public List<File> FILES { get; set; }
    }

    public class File
    {
        [Key]
        public int FID { get; set; }
        public string FN { get; set; }
        public int StuffSID { get; set; }
    }
}
/*
        // GetByJson
        public async Task<IActionResult> Get()
        {
            return Ok(await _context.Stuff.ToListAsync());
        }
        public async Task<IActionResult> Search(int? id)
        {
            if (id == null)
            {
                return Ok("Please insert ID");
            }

            var stuff = await _context.Stuff
                .FirstOrDefaultAsync(m => m.ID == id);
            if (stuff == null)
            {
                return Ok("This ID have no data");
            }

            return Ok(stuff);
        }

        //Post
        public IActionResult Post()
        {
            return View();
        }
        //POST: 多筆資料
        //public async Task<IActionResult> Edit(int id, [Bind("ID,EQPID,COMPID,FN")] Stuff stuff)
        public async Task<IActionResult> MC([FromBody] List<Stuff> StuffList)
        {
            foreach (Stuff stuff in StuffList)
            {
                _context.Stuff.Add(stuff);
                await _context.SaveChangesAsync();
            }
            return Ok(StuffList);
        }
 */
//[HttpGet]
/*public IActionResult Test()
{
    return Ok("123");
}*/

//[HttpPost]
/*public IActionResult Test([FromBody] Stuff stuff)
{
    return Ok(stuff);
}*/
