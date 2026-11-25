[Route("api/buckets")]
[ApiController]
public class BucketsController(IAmazonS3 s3Client, S3BucketService s3BucketService, ISender sender) : ControllerBase
{

    [HttpGet("get-all-buckets-lol")]
    public async Task<IActionResult> GetAllBucketAsync()
    {
        try
        {
            var data = await s3Client.ListBucketsAsync();
            var buckets = data.Buckets.Select(b => b.BucketName);
            return Ok(buckets);
        }
        catch (Exception ex)
        {
            return BadRequest($"Failed to fetch buckets: {ex.Message}");
        }
    }
}