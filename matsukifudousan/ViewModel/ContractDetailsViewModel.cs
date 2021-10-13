using matsukifudousan.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using System.Drawing;
using System.IO;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace matsukifudousan.ViewModel
{

    public class ContractDetailsViewModel : BaseViewModel

    {
        #region initi
        private string _CurrentDate;
        public string CurrentDate { get => _CurrentDate; set { _CurrentDate = value; OnPropertyChanged(); } }

        //private ObservableCollection<RentalManagementDB> _Rental;
        //public ObservableCollection<RentalManagementDB> Rental { get => _Rental; set { _Rental = value; OnPropertyChanged(); } }
        private string _ContractType;
        public string ContractType { get => _ContractType; set { _ContractType = value; OnPropertyChanged(); } }

        private string _PickupMode;
        public string PickupMode { get => _PickupMode; set { _PickupMode = value; OnPropertyChanged(); } }

        private string _DateCurrent;
        public string DateCurrent { get => _DateCurrent; set { _DateCurrent = value; OnPropertyChanged(); } }

        private string _ContractDate;
        public string ContractDate { get => _ContractDate; set { _ContractDate = value; OnPropertyChanged(); } }

        private string _ContractBegin;
        public string ContractBegin { get => _ContractBegin; set { _ContractBegin = value; OnPropertyChanged(); } }

        private string _ContractEnd;
        public string ContractEnd { get => _ContractEnd; set { _ContractEnd = value; OnPropertyChanged(); } }

        private string _OwnerName;
        public string OwnerName { get => _OwnerName; set { _OwnerName = value; OnPropertyChanged(); } }

        private string _OwnerBirthday;
        public string OwnerBirthday { get => _OwnerBirthday; set { _OwnerBirthday = value; OnPropertyChanged(); } }

        private string _OwnerAddress;
        public string OwnerAddress { get => _OwnerAddress; set { _OwnerAddress = value; OnPropertyChanged(); } }

        private string _OwnerAddressNo;
        public string OwnerAddressNo { get => _OwnerAddressNo; set { _OwnerAddressNo = value; OnPropertyChanged(); } }

        private string _OwnerTel;
        public string OwnerTel { get => _OwnerTel; set { _OwnerTel = value; OnPropertyChanged(); } }

        private string _RenterName;
        public string RenterName { get => _RenterName; set { _RenterName = value; OnPropertyChanged(); } }

        private string _RenterBirthday;
        public string RenterBirthday { get => _RenterBirthday; set { _RenterBirthday = value; OnPropertyChanged(); } }

        private string _RenterAddress;
        public string RenterAddress { get => _RenterAddress; set { _RenterAddress = value; OnPropertyChanged(); } }

        private string _RenterAddressNo;
        public string RenterAddressNo { get => _RenterAddressNo; set { _RenterAddressNo = value; OnPropertyChanged(); } }

        private string _RenterTel;
        public string RenterTel { get => _RenterTel; set { _RenterTel = value; OnPropertyChanged(); } }

        private string _RentName;
        public string RentName { get => _RentName; set { _RentName = value; OnPropertyChanged(); } }

        private string _RentBirthday;
        public string RentBirthday { get => _RentBirthday; set { _RentBirthday = value; OnPropertyChanged(); } }

        private string _RentAddress;
        public string RentAddress { get => _RentAddress; set { _RentAddress = value; OnPropertyChanged(); } }

        private string _RentTel;
        public string RentTel { get => _RentTel; set { _RentTel = value; OnPropertyChanged(); } }

        private string _ResidentName1;
        public string ResidentName1 { get => _ResidentName1; set { _ResidentName1 = value; OnPropertyChanged(); } }

        private string _ResidentBirthday1;
        public string ResidentBirthday1 { get => _ResidentBirthday1; set { _ResidentBirthday1 = value; OnPropertyChanged(); } }

        private string _ResidentName2;
        public string ResidentName2 { get => _ResidentName2; set { _ResidentName2 = value; OnPropertyChanged(); } }

        private string _ResidentBirthday2;
        public string ResidentBirthday2 { get => _ResidentBirthday2; set { _ResidentBirthday2 = value; OnPropertyChanged(); } }

        private string _ResidentName3;
        public string ResidentName3 { get => _ResidentName3; set { _ResidentName3 = value; OnPropertyChanged(); } }

        private string _ResidentBirthday3;
        public string ResidentBirthday3 { get => _ResidentBirthday3; set { _ResidentBirthday3 = value; OnPropertyChanged(); } }

        private string _Location;
        public string Location { get => _Location; set { _Location = value; OnPropertyChanged(); } }

        private string _LocationName;
        public string LocationName { get => _LocationName; set { _LocationName = value; OnPropertyChanged(); } }

        private string _IssueRoom;
        public string RIssueRooment { get => _IssueRoom; set { _IssueRoom = value; OnPropertyChanged(); } }

        private string _HouseNumber;
        public string HouseNumber { get => _HouseNumber; set { _HouseNumber = value; OnPropertyChanged(); } }

        private string _Type;
        public string Type { get => _Type; set { _Type = value; OnPropertyChanged(); } }

        private string _Structure;
        public string Structure { get => _Structure; set { _Structure = value; OnPropertyChanged(); } }

        private string _OuterWall;
        public string OuterWall { get => _OuterWall; set { _OuterWall = value; OnPropertyChanged(); } }

        private string _FloorPlan1;
        public string FloorPlan1 { get => _FloorPlan1; set { _FloorPlan1 = value; OnPropertyChanged(); } }

        private string _FloorPlan2;
        public string FloorPlan2 { get => _FloorPlan2; set { _FloorPlan2 = value; OnPropertyChanged(); } }

        private string _PakingYesNo;
        public string PakingYesNo { get => _PakingYesNo; set { _PakingYesNo = value; OnPropertyChanged(); } }

        private string _ParkingForm;
        public string ParkingForm { get => _ParkingForm; set { _ParkingForm = value; OnPropertyChanged(); } }

        private string _UsedNumber1;
        public string UsedNumber1 { get => _UsedNumber1; set { _UsedNumber1 = value; OnPropertyChanged(); } }

        private string _UsedNumber2;
        public string UsedNumber2 { get => _UsedNumber2; set { _UsedNumber2 = value; OnPropertyChanged(); } }

        private string _UsedNumber3;
        public string UsedNumber3 { get => _UsedNumber3; set { _UsedNumber3 = value; OnPropertyChanged(); } }

        private string _ParkingLocation;
        public string ParkingLocation { get => _ParkingLocation; set { _ParkingLocation = value; OnPropertyChanged(); } }

        private string _Electricity;
        public string Electricity { get => _Electricity; set { _Electricity = value; OnPropertyChanged(); } }

        private string _CurrentSupplier;
        public string CurrentSupplier { get => _CurrentSupplier; set { _CurrentSupplier = value; OnPropertyChanged(); } }

        private string _Gas;
        public string Gas { get => _Gas; set { _Gas = value; OnPropertyChanged(); } }

        private string _GasType;
        public string GasType { get => _GasType; set { _GasType = value; OnPropertyChanged(); } }

        private string _Supplier;
        public string Supplier { get => _Supplier; set { _Supplier = value; OnPropertyChanged(); } }

        private string _WaterCrew;
        public string WaterCrew { get => _WaterCrew; set { _WaterCrew = value; OnPropertyChanged(); } }

        private string _WaterTank;
        public string WaterTank { get => _WaterTank; set { _WaterTank = value; OnPropertyChanged(); } }

        private string _Toilet;
        public string Toilet { get => _Toilet; set { _Toilet = value; OnPropertyChanged(); } }

        private string _ProcessEquipment;
        public string ProcessEquipment { get => _ProcessEquipment; set { _ProcessEquipment = value; OnPropertyChanged(); } }

        private string _Sink;
        public string Sink { get => _Sink; set { _Sink = value; OnPropertyChanged(); } }

        private string _Faucet;
        public string Faucet { get => _Faucet; set { _Faucet = value; OnPropertyChanged(); } }

        private string _Kitchen;
        public string Kitchen { get => _Kitchen; set { _Kitchen = value; OnPropertyChanged(); } }

        private string _WaterHeater;
        public string WaterHeater { get => _WaterHeater; set { _WaterHeater = value; OnPropertyChanged(); } }

        private string _Stove;
        public string Stove { get => _Stove; set { _Stove = value; OnPropertyChanged(); } }

        private string _Bathroom;
        public string Bathroom { get => _Bathroom; set { _Bathroom = value; OnPropertyChanged(); } }

        private string _Shower;
        public string Shower { get => _Shower; set { _Shower = value; OnPropertyChanged(); } }

        private string _Reheating;
        public string Reheating { get => _Reheating; set { _Reheating = value; OnPropertyChanged(); } }

        private string _ShowerWith;
        public string ShowerWith { get => _ShowerWith; set { _ShowerWith = value; OnPropertyChanged(); } }

        private string _Bathtub;
        public string Bathtub { get => _Bathtub; set { _Bathtub = value; OnPropertyChanged(); } }

        private string _WashingMachine;
        public string WashingMachine { get => _WashingMachine; set { _WashingMachine = value; OnPropertyChanged(); } }

        private string _ConnectionBracket;
        public string ConnectionBracket { get => _ConnectionBracket; set { _ConnectionBracket = value; OnPropertyChanged(); } }

        private string _LightingEquipment;
        public string LightingEquipment { get => _LightingEquipment; set { _LightingEquipment = value; OnPropertyChanged(); } }

        private string _LightBulbBall;
        public string LightBulbBall { get => _LightBulbBall; set { _LightBulbBall = value; OnPropertyChanged(); } }

        private string _TelevisionAntenna;
        public string TelevisionAntenna { get => _TelevisionAntenna; set { _TelevisionAntenna = value; OnPropertyChanged(); } }

        private string _FixedTelephone;
        public string FixedTelephone { get => _FixedTelephone; set { _FixedTelephone = value; OnPropertyChanged(); } }

        private string _Phone;
        public string Phone { get => _Phone; set { _Phone = value; OnPropertyChanged(); } }

        private string _InternetEquipment;
        public string InternetEquipment { get => _InternetEquipment; set { _InternetEquipment = value; OnPropertyChanged(); } }

        private string _Provider;
        public string Provider { get => _Provider; set { _Provider = value; OnPropertyChanged(); } }

        private string _Router;
        public string Router { get => _Router; set { _Router = value; OnPropertyChanged(); } }

        private string _AirConditioning;
        public string AirConditioning { get => _AirConditioning; set { _AirConditioning = value; OnPropertyChanged(); } }

        private string _Elevator;
        public string Elevator { get => _Elevator; set { _Elevator = value; OnPropertyChanged(); } }

        private string _GarbageStorage;
        public string GarbageStorage { get => _GarbageStorage; set { _GarbageStorage = value; OnPropertyChanged(); } }

        private string _Pet;
        public string Pet { get => _Pet; set { _Pet = value; OnPropertyChanged(); } }

        private string _EvacutionLadder;
        public string EvacutionLadder { get => _EvacutionLadder; set { _EvacutionLadder = value; OnPropertyChanged(); } }

        private string _BicycleParkingSpace;
        public string BicycleParkingSpace { get => _BicycleParkingSpace; set { _BicycleParkingSpace = value; OnPropertyChanged(); } }

        private string _DoorPocket;
        public string DoorPocket { get => _DoorPocket; set { _DoorPocket = value; OnPropertyChanged(); } }

        private string _ScreenDoor;
        public string ScreenDoor { get => _ScreenDoor; set { _ScreenDoor = value; OnPropertyChanged(); } }

        private string _FireAlarm;
        public string FireAlarm { get => _FireAlarm; set { _FireAlarm = value; OnPropertyChanged(); } }

        private string _FireExtinguisher;
        public string FireExtinguisher { get => _FireExtinguisher; set { _FireExtinguisher = value; OnPropertyChanged(); } }

        private string _FireHydrant;
        public string FireHydrant { get => _FireHydrant; set { _FireHydrant = value; OnPropertyChanged(); } }

        private string _Storage;
        public string Storage { get => _Storage; set { _Storage = value; OnPropertyChanged(); } }

        private string _InstallationSunlight;
        public string InstallationSunlight { get => _InstallationSunlight; set { _InstallationSunlight = value; OnPropertyChanged(); } }

        private string _UseNoYes;
        public string UseNoYes { get => _UseNoYes; set { _UseNoYes = value; OnPropertyChanged(); } }

        private string _HotSpring;
        public string HotSpring { get => _HotSpring; set { _HotSpring = value; OnPropertyChanged(); } }

        private string _OtherBuildings;
        public string OtherBuildings { get => _OtherBuildings; set { _OtherBuildings = value; OnPropertyChanged(); } }

        private string _OtherConditions;
        public string OtherConditions { get => _OtherConditions; set { _OtherConditions = value; OnPropertyChanged(); } }

        private string _TransportationFacilities;
        public string TransportationFacilities { get => _TransportationFacilities; set { _TransportationFacilities = value; OnPropertyChanged(); } }

        private string _Rent;
        public string Rent { get => _Rent; set { _Rent = value; OnPropertyChanged(); } }

        private string _CommonServiceFee;
        public string CommonServiceFee { get => _CommonServiceFee; set { _CommonServiceFee = value; OnPropertyChanged(); } }

        private string _CATVFee;
        public string CATVFee { get => _CATVFee; set { _CATVFee = value; OnPropertyChanged(); } }

        private string _ParkingFee;
        public string ParkingFee { get => _ParkingFee; set { _ParkingFee = value; OnPropertyChanged(); } }

        private string _SecurityDeposit;
        public string SecurityDeposit { get => _SecurityDeposit; set { _SecurityDeposit = value; OnPropertyChanged(); } }

        private string _KeyMoney;
        public string KeyMoney { get => _KeyMoney; set { _KeyMoney = value; OnPropertyChanged(); } }

        private string _RentForMonth;
        public string RentForMonth { get => RentForMonth; set { RentForMonth = value; OnPropertyChanged(); } }

        private string _CommonServiceFeeMonth;
        public string CommonServiceFeeMonth { get => _CommonServiceFeeMonth; set { _CommonServiceFeeMonth = value; OnPropertyChanged(); } }

        private string _CATVFeeMonth;
        public string CATVFeeMonth { get => _CATVFeeMonth; set { _CATVFeeMonth = value; OnPropertyChanged(); } }

        private string _ParkingFeeMonth;
        public string ParkingFeeMonth { get => _ParkingFeeMonth; set { _ParkingFeeMonth = value; OnPropertyChanged(); } }

        private string _NextMonthFee;
        public string NextMonthFee { get => _NextMonthFee; set { _NextMonthFee = value; OnPropertyChanged(); } }

        private string _RentalInsurancePremium;
        public string RentalInsurancePremium { get => _RentalInsurancePremium; set { _RentalInsurancePremium = value; OnPropertyChanged(); } }

        private string _RentalGuaranteeFee;
        public string RentalGuaranteeFee { get => _RentalGuaranteeFee; set { _RentalGuaranteeFee = value; OnPropertyChanged(); } }

        private string _FeeTaxIncluded;
        public string FeeTaxIncluded { get => _FeeTaxIncluded; set { _FeeTaxIncluded = value; OnPropertyChanged(); } }

        private string _Total;
        public string Total { get => _Total; set { _Total = value; OnPropertyChanged(); } }

        private object _Choose1;
        public object Choose1 { get => _Choose1; set { _Choose1 = value; OnPropertyChanged(); } }

        private object _Choose2;
        public object Choose2 { get => _Choose2; set { _Choose2 = value; OnPropertyChanged(); } }
        #endregion

        private string _Electronic;
        public string Electronic { get => _Electronic; set { _Electronic = value; OnPropertyChanged(); } }
        public ContractDetailsViewModel()
        {
            DateTime today = DateTime.Today;

            CurrentDate = DateTime.Now.ToString("yyyy/MM/dd");


            ParkingFee = DataProvider.Ins.DB.RentalManagementDB.Where(o => o.HouseNo == "1").First().Parking;
            Rent = DataProvider.Ins.DB.RentalManagementDB.Where(o => o.HouseNo == "1").First().Rent;
            CommonServiceFee = DataProvider.Ins.DB.RentalManagementDB.Where(o => o.HouseNo == "1").First().CommonFee;
            ParkingFee = DataProvider.Ins.DB.RentalManagementDB.Where(o => o.HouseNo == "1").First().ParkingFee;
            SecurityDeposit = DataProvider.Ins.DB.RentalManagementDB.Where(o => o.HouseNo == "1").First().SecurityDeposit;
            KeyMoney = DataProvider.Ins.DB.RentalManagementDB.Where(o => o.HouseNo == "1").First().KeyMoney;

            Choose1 = new ObservableCollection<string>
                {
                    "有",
                    "無"
                };

            Choose2 = new ObservableCollection<string>
                {
                    "不可",
                    "可"
                };

        }

        
    }
}
