# 🛒 ShopMate CLI
A simple and clean C# command-line eCommerce application where users can buy and sell products.

---

## 🚀 Features
- User registration & login system  
- Add products for sale  
- View all listed products  
- Buy products from other users  
- View your own product listings  
- Check purchase history  
- Simple file/database storage system  

---

## 📦 Tech Stack
- **Language:** C#  
- **Framework:** .NET  
- **Application Type:** Console / CLI  

---

## 📂 Project Structure
```
ShopMate-CLI/
│
├── Models/
│ ├── Cart.cs
│ ├── Order.cs
│ ├── Product.cs
│ └── User.cs
│
├── Services/
│ ├── Auth.cs
│ ├── Home.cs
│ ├── Market.cs
│ └── MyStore.cs
│
├── Utils/
│ └── Utils.cs
│
├── Program.cs
└── README.md
```
---

## 🏁 Run the Project
### 1. Clone the repository  
```bash
git clone https://github.com/manik-babu/shopmate-cli.git
```
### 2. Navigate to the folder
```bash
cd shopmate-cli
```
### 3. Run the application
```bash
dotnet run
```
### Sample Menu (Example)
```bash
1. Login
2. Signup
Choose: 
```
---

## 🛠️ Troubleshoot Dotnet Version Issue
If you face any problem with dotnet version.
### 1. Check installed dotnet version in your machine
```bash
dotnet --version
```
### 2. Update shopmate-cli.csproj file
Change net version in TargetFramework with your installed dotnet version
```csproj
<TargetFramework>net[YOUR DOTNET VERSION]</TargetFramework>
```
### 3. Open Terminal and restore project dependencies
```bash
dotnet restore
```
### 4. Run the application
```bash
dotnet run
```