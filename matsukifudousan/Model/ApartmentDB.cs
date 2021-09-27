//------------------------------------------------------------------------------
// <auto-generated>
//     このコードはテンプレートから生成されました。
//
//     このファイルを手動で変更すると、アプリケーションで予期しない動作が発生する可能性があります。
//     このファイルに対する手動の変更は、コードが再生成されると上書きされます。
// </auto-generated>
//------------------------------------------------------------------------------

namespace matsukifudousan.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class ApartmentDB
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ApartmentDB()
        {
            this.ImageDB = new HashSet<ImageDB>();
        }
    
        public string ApartmentHouseNo { get; set; }
        public string ApartmentHouseName { get; set; }
        public string ApartmentPost { get; set; }
        public string ApartmentAddress { get; set; }
        public string NearestSation { get; set; }
        public string Price { get; set; }
        public string FloorPlanType { get; set; }
        public string FloorPlanDetails { get; set; }
        public string OccupiedArea { get; set; }
        public string BalconyArea { get; set; }
        public string LocationNumberFloors { get; set; }
        public string TotalUnits { get; set; }
        public string BuildingStructure { get; set; }
        public string DateConstruction { get; set; }
        public string ConstructionCompany { get; set; }
        public string ManagementCompany { get; set; }
        public string ManagementForm { get; set; }
        public string ManagementFee { get; set; }
        public string RepairReserveFund { get; set; }
        public string OtherFee { get; set; }
        public string Parking { get; set; }
        public string CurrentSituation { get; set; }
        public string DeliveryConditionTime { get; set; }
        public string TransactionMode { get; set; }
        public string RoadsideSituation { get; set; }
        public string MainEquipment { get; set; }
        public string EquipmentEachHouse { get; set; }
        public string SchoolDistrict { get; set; }
        public string NeighborhoodInformation { get; set; }
        public string Remarks { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ImageDB> ImageDB { get; set; }
    }
}
