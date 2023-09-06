﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityModels.ViewModel.ScheduleExamVM
{
    public class ScheduleExamInfoVm
    {
        public int Id { get; set; }
        [Required]
        public int BatchId { get; set; }
        [ForeignKey("BatchId")]
        public virtual Batch Batch { get; set; }
        [Required]
        public int ExamId { get; set; }
        [ForeignKey("ExamId")]
        public virtual Exam Exam { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Schedule { get; set; }
    }
}
