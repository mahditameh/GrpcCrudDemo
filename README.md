
gRPC CRUD Example - Person Service
==================================

این پروژه یک نمونه پیاده‌سازی CRUD ساده برای مدیریت اشخاص است که با استفاده از gRPC و .NET انجام شده است. در این پروژه از Protocol Buffers به‌جای REST API برای ارتباط بین کلاینت و سرور استفاده شده است.

🧱 ساختار مدل
-------------
مدل شخص شامل فیلدهای زیر است:
- Id (شناسه یکتا)
- FirstName (نام)
- LastName (نام خانوادگی)
- NationalCode (کد ملی)
- BirthDate (تاریخ تولد - yyyy-MM-dd)

⚙️ تکنولوژی‌ها و ابزارها
------------------------
- .NET 9.0
- gRPC
- Protocol Buffers
- C#

🗂 ساختار پروژه
---------------
GrpcCrudDemo/
│
├── Protos/
│   └── person.proto       # تعریف gRPC service و پیام‌ها
│
├── Models/
│   └── Person.cs          # مدل شخص برای نگهداری داده‌ها در حافظه
│
├── Services/
│   └── PersonServiceImpl.cs # پیاده‌سازی سرویس gRPC سمت سرور
│
├── GrpcCrudDemo.csproj    # فایل پروژه اصلی
└── README.md              # این فایل

🔧 راه‌اندازی پروژه
--------------------
1. پیش‌نیازها:
   - نصب .NET SDK (نسخه 9)
   - نصب ابزار gRPC:
     dotnet add package Grpc.AspNetCore
     dotnet add package Grpc.Tools

2. بیلد پروژه:
   dotnet build

   (فایل‌های gRPC به صورت خودکار از روی person.proto تولید می‌شن.)

3. اجرای پروژه:
   dotnet run

📬 تعریف سرویس‌ها در Proto
----------------------------
service PersonService {
  rpc CreatePerson (PersonRequest) returns (PersonResponse);
  rpc GetPerson (PersonIdRequest) returns (PersonResponse);
  rpc UpdatePerson (PersonRequest) returns (PersonResponse);
  rpc DeletePerson (PersonIdRequest) returns (DeleteResponse);
}

❗ مدیریت خطا
-------------
در هر پاسخ، دو فیلد Status و Message وجود دارند تا وضعیت عملیات مشخص شود. مثلاً:

{
  "status": "Error",
  "message": "Person not found"
}

📚 منابع استفاده‌شده
----------------------
- https://learn.microsoft.com/en-us/aspnet/core/grpc/
- https://grpc.io/docs/
- https://developers.google.com/protocol-buffers/

📝 یادداشت
-----------
در این پروژه داده‌ها در حافظه (List<Person>) ذخیره می‌شن و برای سادگی از دیتابیس استفاده نشده. در نسخه‌های بعدی می‌تونید از EF Core و دیتابیس SQL استفاده کنید.
