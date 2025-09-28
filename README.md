# 🐱 Purrfect Blog

[![CI/CD](https://github.com/krzsmal/purrfect-blog-starter-1758622165/actions/workflows/cicd.yaml/badge.svg)](https://github.com/krzsmal/purrfect-blog-starter-1758622165/actions/workflows/cicd.yaml)

## 📖 About

PurrfectBlog is a simple blogging platform built using ASP.NET MVC, Entity Framework, and Bootstrap. It provides a full CRUD (Create, Read, Update, Delete) interface for managing blog posts with a focus on simplicity and user experience. The application features form validation, error handling, and a responsive design that works seamlessly across different devices.

The project also shows how to use common web development practices such as automated testing, CI/CD deployment, and the MVC pattern to keep the code organized and easy to maintain.


## 🌐 Demo

**Live:** https://purrfectblog-d6fbeqfhgdcsduhr.polandcentral-01.azurewebsites.net

⚠️ Hosted on Azure Free Tier (F1). The app may take a few seconds to "wake up" on the first request after inactivity and may require a manual refresh to load properly.

## 🧱 Tech Stack

- **Backend:** ASP.NET MVC 5 (.NET Framework 4.7)
- **Database:** Entity Framework 6.5.1 with Code First migrations
- **Frontend:** Bootstrap 5, jQuery 3.7.0, HTML5, CSS3
- **Testing:** MSTest Framework, Moq, FluentAssertions
- **Bundling:** ASP.NET Web Optimization
- **Development:** Visual Studio, IIS Express
- **Deployment:** Azure App Service with automated CI/CD via GitHub Actions

## ✨ Features

1. **Blog Post Management:** Complete CRUD operations for blog posts with title, content, and category fields
2. **Data Validation:** Server-side validation with detailed error messages and form state preservation
3. **Responsive Design:** Bootstrap-powered responsive UI that works on desktop, tablet, and mobile devices
4. **Error Handling:** Custom error pages for 400, 404, and 500 errors with proper HTTP status codes
5. **Entity Framework Integration:** Code First approach with automatic database migrations
6. **Anti-Forgery Protection:** CSRF protection on all form submissions for enhanced security
7. **Success Notifications:** User-friendly feedback messages using TempData for form operations
8. **Recent Posts Display:** Homepage showcasing the 3 most recent blog posts
9. **Post Categorization:** Organize posts with custom categories for better content management
10. **Contact Page:** Static contact page for user inquiries
11. **Automated Testing:** Comprehensive test suite covering controllers, models, and routing
12. **CI/CD Pipeline:** Automated build, test, and deployment using GitHub Actions

## 🚀 Future Enhancements

The following features are planned for future development to enhance the blogging platform:

### 👤 User Authentication & Authorization
- **User Registration:** Allow users to create accounts with email verification
- **Login/Logout System:** Secure authentication using ASP.NET Identity
- **User Profiles:** Personal profile pages with user information and post history
- **Role-based Access:** Admin, Editor, and Author roles with different permissions
- **Password Reset:** Secure password recovery via email

### 📝 Advanced Blog Features
- **Author Attribution:** Associate blog posts with specific user accounts
- **Post Comments:** Allow readers to comment on blog posts with moderation
- **Like/Dislike System:** Enable users to rate posts
- **Image Upload:** File upload system with validation and optimization

### 🔍 Enhanced User Experience
- **Search Functionality:** Full-text search across blog posts and categories
- **Post Pagination:** Navigate through large numbers of posts efficiently
- **Email Subscriptions:** Newsletter signup for new post notifications

## 🖼️ Screenshots

<table>
  <tr>
    <td colspan="2" align="center">
      <img src="https://github.com/user-attachments/assets/9f90b761-0143-4d5e-b278-eb8b3934d2b5" alt="Image 1">
    </td>
  </tr>
  <tr>
    <td>
      <img src="https://github.com/user-attachments/assets/314af698-a418-4206-9b3f-382d123c374c" alt="Image 2">
    </td>
    <td>
      <img src="https://github.com/user-attachments/assets/c86c87a0-30c4-44e7-94ab-161d314a4e8b" alt="Image 3">
    </td>
  </tr>
    <tr>
    <td>
      <img src="https://github.com/user-attachments/assets/c1ab316d-82c5-4826-8fb4-11f12383cc72" alt="Image 4">
    </td>
    <td>
      <img src="https://github.com/user-attachments/assets/a051fcb7-a4ba-496b-8291-64d1de5f9fe7" alt="Image 5">
    </td>
  </tr>
    </tr>
    <tr>
    <td>
      <img src="https://github.com/user-attachments/assets/635ed6a7-ca78-485b-b12f-0b2bdc28e521" alt="Image 6">
    </td>
    <td>
      <img src="https://github.com/user-attachments/assets/5f4bd3b9-2b3f-491f-83b6-395f6ce68494" alt="Image 7">
    </td>
  </tr>
</table>