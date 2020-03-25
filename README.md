# MotelManager

## 1. Thông tin
<p>- hiện tại đã có database </p>
<p>- các bạn vào down load database ở file image/MotelData.bak rồi tiến hành attach vào code để có thể run được cơ sở dữ liệu.</p>

## 2. Đã có Database
<p>- Các bạn có thể tự tạo cho mình riêng 1 Database name MotelData và sau đó run bình thường, StringConnection sẽ dựa trên file .json để tìm đến database đấy</p>

## 3. Đọc mẫu ví dụ sau để có thể viết front end tốt hơn
<p>- hiện tại thì chỉ vừa mới có api và chưa có front end nên nếu các bạn muốn viết fron end thì hãy tạo 1 folder ở Motel/View/Home và đặt tên theo yêu cầu của các bạn rồi các bạn có thể code front end ở đó.</p>
<p>- sau khi code được 1 file front-end với tên của các bạn thì các bạn hãy vào file HomeController theo đường dẫn Motel/Controllers/HomeController.cs</p>
- Tiến hành thêm dòng code sau:

<p> [HttpGet(" điền đường dẫn ở đây")] - ví dụ [HttpGet("xinchao")]</p>
<p> public IActionResult "Tên file code front end của các bạn"() => View()</p>

<p> ví dụ mình vừa tạo 1 file Index.cshtml thì code của mình sẽ:</p>
<pre><code>[HttpGet("index")]
public IActionResult Index()=>View();
</code></pre>

