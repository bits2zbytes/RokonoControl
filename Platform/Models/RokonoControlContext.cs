﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Rokono_Control.Models
{
    public partial class RokonoControlContext : DbContext
    {
        public RokonoControlContext()
        {
        }

        public RokonoControlContext(DbContextOptions<RokonoControlContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AssociatedBoardWorkItems> AssociatedBoardWorkItems { get; set; }
        public virtual DbSet<AssociatedBranchCommits> AssociatedBranchCommits { get; set; }
        public virtual DbSet<AssociatedCommitFiles> AssociatedCommitFiles { get; set; }
        public virtual DbSet<AssociatedProjectBoards> AssociatedProjectBoards { get; set; }
        public virtual DbSet<AssociatedProjectBuilds> AssociatedProjectBuilds { get; set; }
        public virtual DbSet<AssociatedProjectChangelogs> AssociatedProjectChangelogs { get; set; }
        public virtual DbSet<AssociatedProjectIterations> AssociatedProjectIterations { get; set; }
        public virtual DbSet<AssociatedProjectMemberRights> AssociatedProjectMemberRights { get; set; }
        public virtual DbSet<AssociatedProjectMembers> AssociatedProjectMembers { get; set; }
        public virtual DbSet<AssociatedRepositoryBranches> AssociatedRepositoryBranches { get; set; }
        public virtual DbSet<AssociatedWorkItemChangelogs> AssociatedWorkItemChangelogs { get; set; }
        public virtual DbSet<AssociatedWorkItemMessages> AssociatedWorkItemMessages { get; set; }
        public virtual DbSet<AssociatedWrorkItemChildren> AssociatedWrorkItemChildren { get; set; }
        public virtual DbSet<Boards> Boards { get; set; }
        public virtual DbSet<Branches> Branches { get; set; }
        public virtual DbSet<Builds> Builds { get; set; }
        public virtual DbSet<Changelogs> Changelogs { get; set; }
        public virtual DbSet<Commits> Commits { get; set; }
        public virtual DbSet<Efforts> Efforts { get; set; }
        public virtual DbSet<Files> Files { get; set; }
        public virtual DbSet<Projects> Projects { get; set; }
        public virtual DbSet<Repository> Repository { get; set; }
        public virtual DbSet<Risks> Risks { get; set; }
        public virtual DbSet<UserAccounts> UserAccounts { get; set; }
        public virtual DbSet<UserRights> UserRights { get; set; }
        public virtual DbSet<ValueAreas> ValueAreas { get; set; }
        public virtual DbSet<WorkItem> WorkItem { get; set; }
        public virtual DbSet<WorkItemActivity> WorkItemActivity { get; set; }
        public virtual DbSet<WorkItemAreas> WorkItemAreas { get; set; }
        public virtual DbSet<WorkItemIterations> WorkItemIterations { get; set; }
        public virtual DbSet<WorkItemMessage> WorkItemMessage { get; set; }
        public virtual DbSet<WorkItemPriorities> WorkItemPriorities { get; set; }
        public virtual DbSet<WorkItemRealtionshipType> WorkItemRealtionshipType { get; set; }
        public virtual DbSet<WorkItemReasons> WorkItemReasons { get; set; }
        public virtual DbSet<WorkItemRelations> WorkItemRelations { get; set; }
        public virtual DbSet<WorkItemSeverities> WorkItemSeverities { get; set; }
        public virtual DbSet<WorkItemStates> WorkItemStates { get; set; }
        public virtual DbSet<WorkItemTypes> WorkItemTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=192.168.1.3;Database=RokonoControl;User ID=kristifor;Password=';;@Kakadu';");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AssociatedBoardWorkItems>(entity =>
            {
                entity.HasOne(d => d.Board)
                    .WithMany(p => p.AssociatedBoardWorkItems)
                    .HasForeignKey(d => d.BoardId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Associate__Board__5070F446");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.AssociatedBoardWorkItems)
                    .HasForeignKey(d => d.ProjectId)
                    .HasConstraintName("FK__Associate__Proje__571DF1D5");

                entity.HasOne(d => d.WorkItem)
                    .WithMany(p => p.AssociatedBoardWorkItems)
                    .HasForeignKey(d => d.WorkItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Associate__WorkI__5165187F");
            });

            modelBuilder.Entity<AssociatedBranchCommits>(entity =>
            {
                entity.HasOne(d => d.Branch)
                    .WithMany(p => p.AssociatedBranchCommits)
                    .HasForeignKey(d => d.BranchId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Associate__Branc__2EDAF651");

                entity.HasOne(d => d.Commit)
                    .WithMany(p => p.AssociatedBranchCommits)
                    .HasForeignKey(d => d.CommitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Associate__Commi__2CF2ADDF");
            });

            modelBuilder.Entity<AssociatedCommitFiles>(entity =>
            {
                entity.Property(e => e.DateOfCommit).HasColumnType("datetime");

                entity.HasOne(d => d.Commit)
                    .WithMany(p => p.AssociatedCommitFiles)
                    .HasForeignKey(d => d.CommitId)
                    .HasConstraintName("FK__Associate__Commi__4D5F7D71");

                entity.HasOne(d => d.File)
                    .WithMany(p => p.AssociatedCommitFiles)
                    .HasForeignKey(d => d.FileId)
                    .HasConstraintName("FK__Associate__FileI__73852659");
            });

            modelBuilder.Entity<AssociatedProjectBoards>(entity =>
            {
                entity.HasOne(d => d.Board)
                    .WithMany(p => p.AssociatedProjectBoards)
                    .HasForeignKey(d => d.BoardId)
                    .HasConstraintName("FK__Associate__Board__0E391C95");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.AssociatedProjectBoards)
                    .HasForeignKey(d => d.ProjectId)
                    .HasConstraintName("FK__Associate__Proje__0F2D40CE");
            });

            modelBuilder.Entity<AssociatedProjectBuilds>(entity =>
            {
                entity.HasOne(d => d.Build)
                    .WithMany(p => p.AssociatedProjectBuilds)
                    .HasForeignKey(d => d.BuildId)
                    .HasConstraintName("FK__Associate__Build__7B5B524B");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.AssociatedProjectBuilds)
                    .HasForeignKey(d => d.ProjectId)
                    .HasConstraintName("FK__Associate__Proje__7D439ABD");

                entity.HasOne(d => d.Repository)
                    .WithMany(p => p.AssociatedProjectBuilds)
                    .HasForeignKey(d => d.RepositoryId)
                    .HasConstraintName("FK__Associate__Repos__7C4F7684");
            });

            modelBuilder.Entity<AssociatedProjectChangelogs>(entity =>
            {
                entity.HasOne(d => d.Log)
                    .WithMany(p => p.AssociatedProjectChangelogs)
                    .HasForeignKey(d => d.LogId)
                    .HasConstraintName("FK__Associate__LogId__6BAEFA67");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.AssociatedProjectChangelogs)
                    .HasForeignKey(d => d.ProjectId)
                    .HasConstraintName("FK__Associate__Proje__6ABAD62E");
            });

            modelBuilder.Entity<AssociatedProjectIterations>(entity =>
            {
                entity.HasOne(d => d.Iteration)
                    .WithMany(p => p.AssociatedProjectIterations)
                    .HasForeignKey(d => d.IterationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AssociatedProjectIterations_WorkItemIterations");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.AssociatedProjectIterations)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AssociatedProjectIterations_Projects");
            });

            modelBuilder.Entity<AssociatedProjectMemberRights>(entity =>
            {
                entity.HasOne(d => d.Project)
                    .WithMany(p => p.AssociatedProjectMemberRights)
                    .HasForeignKey(d => d.ProjectId)
                    .HasConstraintName("FK_AssociatedProjectMemberRights_Projects");

                entity.HasOne(d => d.Rights)
                    .WithMany(p => p.AssociatedProjectMemberRights)
                    .HasForeignKey(d => d.RightsId)
                    .HasConstraintName("FK_AssociatedProjectMemberRights_UserRights");

                entity.HasOne(d => d.UserAccount)
                    .WithMany(p => p.AssociatedProjectMemberRights)
                    .HasForeignKey(d => d.UserAccountId)
                    .HasConstraintName("FK_AssociatedProjectMemberRights_UserAccounts");
            });

            modelBuilder.Entity<AssociatedProjectMembers>(entity =>
            {
                entity.HasOne(d => d.Project)
                    .WithMany(p => p.AssociatedProjectMembers)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Associate__Proje__5535A963");

                entity.HasOne(d => d.Repository)
                    .WithMany(p => p.AssociatedProjectMembers)
                    .HasForeignKey(d => d.RepositoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Associate__Repos__5629CD9C");

                entity.HasOne(d => d.UserAccount)
                    .WithMany(p => p.AssociatedProjectMembers)
                    .HasForeignKey(d => d.UserAccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Associate__UserA__5441852A");
            });

            modelBuilder.Entity<AssociatedRepositoryBranches>(entity =>
            {
                entity.HasOne(d => d.Branch)
                    .WithMany(p => p.AssociatedRepositoryBranches)
                    .HasForeignKey(d => d.BranchId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Associate__Branc__45BE5BA9");

                entity.HasOne(d => d.Repository)
                    .WithMany(p => p.AssociatedRepositoryBranches)
                    .HasForeignKey(d => d.RepositoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Associate__Repos__47A6A41B");
            });

            modelBuilder.Entity<AssociatedWorkItemChangelogs>(entity =>
            {
                entity.Property(e => e.WorkitemId).HasColumnName("workitemId");

                entity.HasOne(d => d.Log)
                    .WithMany(p => p.AssociatedWorkItemChangelogs)
                    .HasForeignKey(d => d.LogId)
                    .HasConstraintName("FK__Associate__LogId__6E8B6712");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.AssociatedWorkItemChangelogs)
                    .HasForeignKey(d => d.ProjectId)
                    .HasConstraintName("FK__Associate__Proje__7073AF84");

                entity.HasOne(d => d.Workitem)
                    .WithMany(p => p.AssociatedWorkItemChangelogs)
                    .HasForeignKey(d => d.WorkitemId)
                    .HasConstraintName("FK__Associate__worki__6F7F8B4B");
            });

            modelBuilder.Entity<AssociatedWorkItemMessages>(entity =>
            {
                entity.HasOne(d => d.Message)
                    .WithMany(p => p.AssociatedWorkItemMessages)
                    .HasForeignKey(d => d.MessageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Associate__Messa__7DCDAAA2");

                entity.HasOne(d => d.WorkItem)
                    .WithMany(p => p.AssociatedWorkItemMessages)
                    .HasForeignKey(d => d.WorkItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Associate__WorkI__7CD98669");
            });

            modelBuilder.Entity<AssociatedWrorkItemChildren>(entity =>
            {
                entity.HasOne(d => d.RelationTypeNavigation)
                    .WithMany(p => p.AssociatedWrorkItemChildren)
                    .HasForeignKey(d => d.RelationType)
                    .HasConstraintName("FK__Associate__Relat__2F9A1060");

                entity.HasOne(d => d.WorkItemChild)
                    .WithMany(p => p.AssociatedWrorkItemChildrenWorkItemChild)
                    .HasForeignKey(d => d.WorkItemChildId)
                    .HasConstraintName("FK__Associate__WorkI__1E6F845E");

                entity.HasOne(d => d.WorkItem)
                    .WithMany(p => p.AssociatedWrorkItemChildrenWorkItem)
                    .HasForeignKey(d => d.WorkItemId)
                    .HasConstraintName("FK__Associate__WorkI__1D7B6025");
            });

            modelBuilder.Entity<Boards>(entity =>
            {
                entity.Property(e => e.BoardName).HasMaxLength(1000);
            });

            modelBuilder.Entity<Branches>(entity =>
            {
                entity.Property(e => e.DateOfCreation).HasColumnType("datetime");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.Branches)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Branches__Projec__2FCF1A8A");
            });

            modelBuilder.Entity<Builds>(entity =>
            {
                entity.Property(e => e.DateOfBuild).HasColumnType("datetime");

                entity.Property(e => e.ReasonName)
                    .IsRequired()
                    .HasMaxLength(600);
            });

            modelBuilder.Entity<Changelogs>(entity =>
            {
                entity.Property(e => e.LogDetails)
                    .IsRequired()
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Commits>(entity =>
            {
                entity.Property(e => e.CommitData).IsRequired();

                entity.Property(e => e.DateOfCommit).HasColumnType("datetime");
            });

            modelBuilder.Entity<Efforts>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.EffortName).HasMaxLength(300);
            });

            modelBuilder.Entity<Files>(entity =>
            {
                entity.Property(e => e.DateOfFile).HasColumnType("datetime");
            });

            modelBuilder.Entity<Projects>(entity =>
            {
                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.HasOne(d => d.Repository)
                    .WithMany(p => p.Projects)
                    .HasForeignKey(d => d.RepositoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Projects__Reposi__4BAC3F29");
            });

            modelBuilder.Entity<Repository>(entity =>
            {
                entity.Property(e => e.FolderPath).IsRequired();
            });

            modelBuilder.Entity<Risks>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.RiskName).HasMaxLength(300);
            });

            modelBuilder.Entity<UserAccounts>(entity =>
            {
                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.FirstName).HasMaxLength(400);

                entity.Property(e => e.GitUsername).HasMaxLength(300);

                entity.Property(e => e.LastName).HasMaxLength(400);

                entity.Property(e => e.Password).IsRequired();
            });

            modelBuilder.Entity<ValueAreas>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ValueAreaName).HasMaxLength(300);
            });

            modelBuilder.Entity<WorkItem>(entity =>
            {
                entity.Property(e => e.Compleated).HasMaxLength(300);

                entity.Property(e => e.DueDate).HasColumnType("datetime");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.ItemPriority).HasColumnName("itemPriority");

                entity.Property(e => e.OriginEstitame).HasMaxLength(300);

                entity.Property(e => e.Remaining).HasMaxLength(300);

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.StoryPoints).HasMaxLength(400);

                entity.HasOne(d => d.ActivityNavigation)
                    .WithMany(p => p.WorkItem)
                    .HasForeignKey(d => d.Activity)
                    .HasConstraintName("FK__WorkItem__Activi__70DDC3D8");

                entity.HasOne(d => d.Area)
                    .WithMany(p => p.WorkItem)
                    .HasForeignKey(d => d.AreaId)
                    .HasConstraintName("FK__WorkItem__AreaId__6754599E");

                entity.HasOne(d => d.AssignedAccountNavigation)
                    .WithMany(p => p.WorkItem)
                    .HasForeignKey(d => d.AssignedAccount)
                    .HasConstraintName("FK__WorkItem__Assign__5CD6CB2B");

                entity.HasOne(d => d.IterationNavigation)
                    .WithMany(p => p.WorkItem)
                    .HasForeignKey(d => d.Iteration)
                    .HasConstraintName("FK__WorkItem__Iterat__73BA3083");

                entity.HasOne(d => d.Priority)
                    .WithMany(p => p.WorkItem)
                    .HasForeignKey(d => d.PriorityId)
                    .HasConstraintName("FK__WorkItem__Priori__6B24EA82");

                entity.HasOne(d => d.ReasonNavigation)
                    .WithMany(p => p.WorkItem)
                    .HasForeignKey(d => d.ReasonId)
                    .HasConstraintName("FK__WorkItem__Reason__76969D2E");

                entity.HasOne(d => d.Relation)
                    .WithMany(p => p.WorkItem)
                    .HasForeignKey(d => d.RelationId)
                    .HasConstraintName("FK__WorkItem__Relati__00200768");

                entity.HasOne(d => d.Risk)
                    .WithMany(p => p.WorkItem)
                    .HasForeignKey(d => d.RiskId)
                    .HasConstraintName("FK__WorkItem__RiskId__17036CC0");

                entity.HasOne(d => d.SeverityNavigation)
                    .WithMany(p => p.WorkItem)
                    .HasForeignKey(d => d.Severity)
                    .HasConstraintName("FK__WorkItem__Severi__6E01572D");

                entity.HasOne(d => d.State)
                    .WithMany(p => p.WorkItem)
                    .HasForeignKey(d => d.StateId)
                    .HasConstraintName("FK__WorkItem__StateI__656C112C");

                entity.HasOne(d => d.ValueArea)
                    .WithMany(p => p.WorkItem)
                    .HasForeignKey(d => d.ValueAreaId)
                    .HasConstraintName("FK__WorkItem__ValueA__1CBC4616");

                entity.HasOne(d => d.WorkItemType)
                    .WithMany(p => p.WorkItem)
                    .HasForeignKey(d => d.WorkItemTypeId)
                    .HasConstraintName("FK__WorkItem__WorkIt__5812160E");
            });

            modelBuilder.Entity<WorkItemActivity>(entity =>
            {
                entity.Property(e => e.ActivityName)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<WorkItemAreas>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AreaName)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<WorkItemIterations>(entity =>
            {
                entity.Property(e => e.IterationName)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<WorkItemMessage>(entity =>
            {
                entity.Property(e => e.DateOfMessage).HasColumnType("datetime");

                entity.HasOne(d => d.Sender)
                    .WithMany(p => p.WorkItemMessage)
                    .HasForeignKey(d => d.SenderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__WorkItemM__Sende__019E3B86");
            });

            modelBuilder.Entity<WorkItemPriorities>(entity =>
            {
                entity.Property(e => e.PriorityName)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<WorkItemRealtionshipType>(entity =>
            {
                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<WorkItemReasons>(entity =>
            {
                entity.Property(e => e.ReasonName)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<WorkItemRelations>(entity =>
            {
                entity.Property(e => e.RelationName).HasMaxLength(300);
            });

            modelBuilder.Entity<WorkItemSeverities>(entity =>
            {
                entity.Property(e => e.SeverityName)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<WorkItemStates>(entity =>
            {
                entity.Property(e => e.StateName).HasMaxLength(300);
            });

            modelBuilder.Entity<WorkItemTypes>(entity =>
            {
                entity.Property(e => e.Icon).HasMaxLength(600);

                entity.Property(e => e.TypeName).HasMaxLength(300);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
