USE [Fancy]
GO
/****** Object:  Table [dbo].[Blog]    Script Date: 15-Feb-18 9:17:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Blog](
	[blog_id] [int] IDENTITY(1,1) NOT NULL,
	[blog_title] [nvarchar](150) NULL,
	[blog_content] [nvarchar](max) NULL,
	[blog_img] [nvarchar](max) NULL,
	[blog_category_id] [int] NULL,
 CONSTRAINT [PK_Blog] PRIMARY KEY CLUSTERED 
(
	[blog_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 15-Feb-18 9:17:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[category_id] [int] IDENTITY(1,1) NOT NULL,
	[category_name] [nvarchar](50) NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[category_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Contact]    Script Date: 15-Feb-18 9:17:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contact](
	[contact_id] [int] IDENTITY(1,1) NOT NULL,
	[contact_phone] [nvarchar](50) NULL,
	[contact_email] [nvarchar](50) NULL,
	[contact_address] [nvarchar](100) NULL,
	[contact_work_time] [nvarchar](100) NULL,
 CONSTRAINT [PK_Contact] PRIMARY KEY CLUSTERED 
(
	[contact_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Feature_Boxes]    Script Date: 15-Feb-18 9:17:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Feature_Boxes](
	[feature_boxes_id] [int] IDENTITY(1,1) NOT NULL,
	[feature_boxes_title] [nvarchar](50) NULL,
	[feature_boxes_icon] [nvarchar](50) NULL,
	[feature_boxes_content] [nvarchar](250) NULL,
	[feature_boxes_url] [nvarchar](350) NULL,
 CONSTRAINT [PK_Feature_Boxes] PRIMARY KEY CLUSTERED 
(
	[feature_boxes_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Industries]    Script Date: 15-Feb-18 9:17:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Industries](
	[industries_id] [int] IDENTITY(1,1) NOT NULL,
	[industries_title] [nvarchar](500) NULL,
	[industries_content] [nvarchar](max) NULL,
	[industries_img] [nvarchar](max) NULL,
	[industries_url] [nvarchar](350) NULL,
 CONSTRAINT [PK_Industries] PRIMARY KEY CLUSTERED 
(
	[industries_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Menu]    Script Date: 15-Feb-18 9:17:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Menu](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[menu_name] [nvarchar](50) NULL,
	[menu_link] [nvarchar](250) NULL,
	[menu_title] [nvarchar](500) NULL,
 CONSTRAINT [PK_Menu] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Messages]    Script Date: 15-Feb-18 9:17:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Messages](
	[message_id] [int] IDENTITY(1,1) NOT NULL,
	[message_name] [nvarchar](50) NULL,
	[message_email] [nvarchar](50) NULL,
	[message_website_url] [nvarchar](350) NULL,
	[message_content] [nvarchar](max) NULL,
 CONSTRAINT [PK_Messages] PRIMARY KEY CLUSTERED 
(
	[message_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Service_Area]    Script Date: 15-Feb-18 9:17:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Service_Area](
	[service_id] [int] IDENTITY(1,1) NOT NULL,
	[service_img] [nvarchar](50) NULL,
	[service_title] [nvarchar](100) NULL,
	[service_content] [nvarchar](300) NULL,
	[service_content_url] [nvarchar](250) NULL,
 CONSTRAINT [PK_Service_Area] PRIMARY KEY CLUSTERED 
(
	[service_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Service_Area_Contents]    Script Date: 15-Feb-18 9:17:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Service_Area_Contents](
	[service_contents_id] [int] IDENTITY(1,1) NOT NULL,
	[service_contents_title] [nvarchar](100) NULL,
	[service_contents_content] [nvarchar](max) NULL,
	[service_contents_icon] [nvarchar](200) NULL,
 CONSTRAINT [PK_Service_Area_Contents] PRIMARY KEY CLUSTERED 
(
	[service_contents_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Slider]    Script Date: 15-Feb-18 9:17:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Slider](
	[slider_id] [int] IDENTITY(1,1) NOT NULL,
	[slider_title] [nvarchar](80) NULL,
	[slider_img] [nvarchar](50) NULL,
	[slider_first_url] [nvarchar](350) NULL,
	[slider_second_url] [nvarchar](350) NULL,
 CONSTRAINT [PK_Slider] PRIMARY KEY CLUSTERED 
(
	[slider_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Testimonials_Slider]    Script Date: 15-Feb-18 9:17:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Testimonials_Slider](
	[testimonials_slider_id] [int] IDENTITY(1,1) NOT NULL,
	[testimonials_slider_icon] [nvarchar](200) NULL,
	[testimonials_slider_content] [nvarchar](max) NULL,
	[testimonials_slider_author] [nvarchar](50) NULL,
	[testimonials_slider_position] [nvarchar](50) NULL,
	[testimonials_slider_img] [nvarchar](100) NULL,
 CONSTRAINT [PK_Testimonials_Slider] PRIMARY KEY CLUSTERED 
(
	[testimonials_slider_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Blog]  WITH CHECK ADD  CONSTRAINT [FK_Blog_Categories] FOREIGN KEY([blog_category_id])
REFERENCES [dbo].[Categories] ([category_id])
GO
ALTER TABLE [dbo].[Blog] CHECK CONSTRAINT [FK_Blog_Categories]
GO
