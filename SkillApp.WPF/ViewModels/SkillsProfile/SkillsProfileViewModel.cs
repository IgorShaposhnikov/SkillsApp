﻿using SkillApp.Core.Enums;
using SkillApp.Core.Models;
using SkillApp.Core.Printouts;
using SkillApp.WPF.Base;
using SkillApp.WPF.Base.Commands;
using SkillApp.WPF.Base.Store;
using SkillApp.WPF.ViewModels.Modal;
using SkillApp.WPF.ViewModels.SkillsProfile.Modal;
using SkillApp.WPF.Views.Pages.Modal;
using System;
using System.Linq;
using System.Windows.Input;

namespace SkillApp.WPF.ViewModels.SkillsProfile
{
    public sealed class SkillsProfileViewModel : VMBase
    {
        private readonly Action<VMBase> _changeCurrentPage;

        public Core.Models.SkillsProfile Profile { get; } = new Core.Models.SkillsProfile();


        #region Commands


        private RelayCommand _openSkillFactoryCommand;
        public ICommand OpenSkillFactoryCommand
        {
            get => _openSkillFactoryCommand ?? (_openSkillFactoryCommand = new RelayCommand(obj =>
            {
                ModalNavigationStore.Instance.Open(new SkillFactoryModalViewModel(Profile.AddSkill, Profile.SkillsCount));
            }));
        }

        private RelayCommand _openSkillEditModalCommand;
        public ICommand OpenSkillEditModalCommand
        {
            get => _openSkillEditModalCommand ?? (_openSkillEditModalCommand = new RelayCommand(obj =>
            {
                ModalNavigationStore.Instance.Open(new SkillEditModalViewModel((ISkill)obj));
            }));
        }

        private RelayCommand _deleteSkillCommand;
        public ICommand DeleteSkillCommand
        {
            get => _deleteSkillCommand ?? (_deleteSkillCommand = new RelayCommand(obj =>
            {
                ModalNavigationStore.Instance.Open(new ModalDialogWindowViewModel(
                    () => Profile.Remove((ISkill)obj),
                    () => { },
                    "Удаление",
                    "Вы действительно хотите удалить навык? \n Все его аспекты будут также удалены!", true
                    ));
            }));
        }


        private RelayCommand _showAspectsCommand;
        public ICommand ShowAspectsCommand
        {
            get => _showAspectsCommand ?? (_showAspectsCommand = new RelayCommand(obj =>
            {
                var skill = (ISkill)obj;
                _changeCurrentPage(
                    new SkillAspectsViewModel(
                        () => { _changeCurrentPage(this); },
                        skill,
                        OpenAspectTransferModal
                        )
                    );
            }));
        }


        private RelayCommand _saveSkillsProfile;
        public ICommand SaveSkillsProfileCommand
        {
            get => _saveSkillsProfile ?? (_saveSkillsProfile = new RelayCommand(obj =>
            {
                ModalNavigationStore.Instance.Open(new SaveSkillsProfileMenuViewModel(Profile));
            }));
        }


        #endregion Commands


        #region Constructors


        public SkillsProfileViewModel(Action<VMBase> changeCurrentPage)
        {
            _changeCurrentPage = changeCurrentPage;
            //Load();
        }


        #endregion Constructors


        #region Public & Protected Methods


        private void OpenAspectTransferModal(ISkill from)
        {
            // Что за хрень тут написана хахахах
            ModalNavigationStore.Instance.Open(new AspectTransferModalViewModel(from, Profile.Skills.ToList<ISkill>()));
        }

        public void Load(string path)
        {
            var skills = XMLPrintout.LoadSkillProfile(path:path);
            //skills.Sort

            foreach (var skill in skills)
            {
                var loadedSkill = new Skill()
                {
                    Id = skill.Id,
                    Name = skill.Name,
                };

                foreach (var aspect in skill.Aspects)
                {
                    var loadedAspect = new Aspect(loadedSkill.RemoveAspect);
                    loadedSkill.AddAspect(loadedAspect);

                    loadedAspect.Id = Int32.Parse(aspect.Id.Split('.')[1]);
                    loadedAspect.ScoreStep = aspect.ScoreStep;
                    loadedAspect.Score = aspect.Score;
                    loadedAspect.Type = aspect.Type;
                    loadedAspect.Explanation = new Explanation(aspect.Explanation, aspect.Type, aspect.Score, aspect.ScoreStep);
                    loadedAspect.Description = aspect.Description;
                    
                    loadedAspect.ExecutionFrequency = aspect.ExecutionFrequency;
                }

                Profile.AddSkill(loadedSkill);
            }
        }


        #endregion Public & Protected Methods
    }
}
