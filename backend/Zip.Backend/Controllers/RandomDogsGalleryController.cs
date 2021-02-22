using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Zip.Backend.Data;
using Zip.Backend.Models;
using Zip.Backend.APIService;


namespace Zip.Backend.Controllers
{
  [Route("[controller]")]
  [ApiController]
  public class RandomDogsGalleryController : ControllerBase
  {
    private readonly GuestBookContext _db;
    public RandomDogsGalleryController(GuestBookContext db)
    {
      _db = db;
    }
    [HttpGet]
    public async Task<IEnumerable<DogsRandomPictures>> Get()
    {
      try
      {
        var _dogsImages=await _db.DogRandomPictures.OrderByDescending(d=>d.Created).Take(8).ToListAsync();
        return _dogsImages;
      }
      catch (Exception ex)
      {
        return (IEnumerable<DogsRandomPictures>)BadRequest($"Error Occured While Returiung values {ex.Message}");
      }   
    }

    [HttpGet]
    [Route("RefreshRandomDogpictures")]
    public async Task<IEnumerable<DogsRandomPictures>> RefreshRandomDogpictures()
    {     
      try
      {
        var _RandomPictureRequest = DogimageFetchService.FetchDogRandownimages().Result;
        var _DogsRandomPictures = await _db.DogRandomPictures.ToListAsync();
        if (_DogsRandomPictures.Count >= 24 && _RandomPictureRequest.Count() > 0)
        {
          _db.DogRandomPictures.RemoveRange(_DogsRandomPictures.Where(d => d.Created != null).OrderBy(c => c.Created).Take(_RandomPictureRequest.Count()).ToList());
          await _db.SaveChangesAsync();
        }
        foreach (var _NewPictures in _RandomPictureRequest)
        {
          var _RandomPictures = new DogsRandomPictures()
          {
            Id = Guid.NewGuid(),
            FileSize = _NewPictures.fileSizeBytes,
            Pictureurl = _NewPictures.url,
            Created = DateTime.Now.ToUniversalTime()
          };
          await _db.DogRandomPictures.AddAsync(_RandomPictures);         
        }
        await _db.SaveChangesAsync();
        var _dogsImages = await _db.DogRandomPictures.OrderByDescending(d => d.Created).Take(8).ToListAsync();
        return _dogsImages;
      }
      catch (Exception ex)
      {
        return (IEnumerable<DogsRandomPictures>)BadRequest($"Error Occured While Returiung values {ex.Message}");
      }

    }
  }
}
