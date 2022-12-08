using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TermWeb.Models
{
    public class Article
    {
        public Article()
        {
            PostDate = DateTime.Now;
        }

        public int Id { get; set; }  // ID

        [Display(Name = "제목")]
        [StringLength(90, MinimumLength = 3)] // 최소 길이 3, 최대 90
        [Required(ErrorMessage = "제목을 입력해 주세요.")] // 필수 입력 항목.
        public string Title { get; set; }  // 제목

        [Display(Name = "카테고리")]
        [Required(ErrorMessage = "머리말을 입력해 주세요.")]
        [StringLength(30)]
        public string Head { get; set; }  // 머릿말 (카테고리, 분류)

        [Display(Name = "특가 진행")]
        public bool IsStillGoing { get; set; } = true; // 특가 이벤트가 진행중인가? - 기한(Deadline)이 넘어가면 자동으로 false.

        [Display(Name = "작성자 ID")]
        [Required]
        [StringLength(30, MinimumLength = 2)]
        public string WriterID { get; set; }  // 작성자 ID

        [Display(Name = "판매처")]
        [Required(ErrorMessage = "판매처를 입력해 주세요.")]
        [StringLength(30)]
        public string MallName { get; set; }  // 특가 이벤트 진행중인 쇼핑몰 이름.

        [Display(Name = "가격")]
        [Required(ErrorMessage = "가격을 입력해 주세요.")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }  // 가격

        [Display(Name = "작성 시간")]
        public DateTime PostDate { get; set; }  // 게시 날짜 - 자동으로 현재 날짜로 지정.

        [Display(Name = "배송비")]
        [Required(ErrorMessage = "배송비를 입력해 주세요. 배송비가 없다면 0을 입력하세요.")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal DeliverPrice { get; set; } = 0;  // 배송비

        [Display(Name = "기타 사항")]
        public string Etc { get; set; }  // 기타 사항

        [Display(Name = "통화")]
        [Required(ErrorMessage = "통화 단위를 선택해 주세요.")]
        public char Currency { get; set; } // 통화 단위 (ex. $) 

        [Display(Name = "특가 기한")]
        [Required(ErrorMessage = "특가 기한을 선택해 주세요.")]
        public DateTime Deadline { get; set; } // 특가 기한.

        [Display(Name = "남은 시간")]
        public string RemainDate { get; set; } // 기한까지 남은 시간.

        [Display(Name = "비밀번호")]
        public string Password { get; set; } // 비밀번호 

        [Display(Name = "원가")]
        [Required(ErrorMessage = "원가를 입력해 주세요.")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal OrigPrice { get ; set; } //원가

        [Display(Name = "링크")]
        public string Link { get; set; } //링크

        [Display(Name = "할인율")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Discount { get; set; } //할인율

        [NotMapped]
        [Display(Name = "비밀번호 확인")]
        [Compare("Password", ErrorMessage = "비밀번호가 일치하지 않습니다.")]
        public string ConfirmPassword { get; set; }

    }

}