using System;
using System.Collections.Generic;
using System.Linq;

namespace Berkeley
{
    public class Berkerley
    {
        private List<Computer> listComputers { get; }
        public Berkerley(List<Computer> listComputers)
        {
            this.listComputers = listComputers;
        }
        public void Execute() 
        {
            // Pega o primeiro computador master.
            var masterComputer = listComputers.FirstOrDefault(x => x.IsMaster);

            if(masterComputer is null)
                masterComputer = SelectMaster();

            int minutePcMaster = (masterComputer.Time.Hour * 60) + masterComputer.Time.Minute;
            var result = TimeMean(masterComputer.Time);

            UpdateTime(result, minutePcMaster);
        }

        // Para escolher um novo master, caso necessário.
        private Computer SelectMaster()
        {
            var computerOnline = this.listComputers.FirstOrDefault(x => x.IsOnline);

            if(computerOnline is null) 
                throw new Exception("Não existe Computadores online.");
            
            computerOnline.IsMaster = true; 
            return computerOnline;
        }       

        // Verifica o relógio de todos os computadores secundários e faz a média
        private int TimeMean(DateTime timeMaster)
        {
            var secondaryPcs = this.listComputers.Where(x => !x.IsOnline).ToList();
            int soma = 0;
            int minutePcMaster = (timeMaster.Hour * 60) + timeMaster.Minute;

            foreach(var item in secondaryPcs)
            {
                soma += ((item.Time.Hour * 60) + item.Time.Minute) - minutePcMaster;
            }

            return (int)soma / this.listComputers.Count();
        }

        // Atualiza o relógio de todos os computadores
        private void UpdateTime(int time, int timeMasterInMinutes)
        {
            int timeInMinutes = 0; 
            foreach(var item in this.listComputers)
            {
                int timeItemInMinutes = ((item.Time.Hour * 60) + item.Time.Minute);
                timeInMinutes = timeItemInMinutes - timeMasterInMinutes;

                if (timeItemInMinutes == timeMasterInMinutes)
                {
                    timeInMinutes += time;
                    item.Time = item.Time.AddMinutes(timeInMinutes);
                }

                if (timeItemInMinutes < timeMasterInMinutes)
                {
                    timeInMinutes = Math.Abs(timeInMinutes) + time;
                    item.Time = item.Time.AddMinutes(timeInMinutes);
                }
                
                if(timeItemInMinutes > timeMasterInMinutes)
                {
                    timeInMinutes -= time;
                    item.Time = item.Time.AddMinutes(-timeInMinutes);
                }
            }
        }
    }
}
