﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     Ten kod został wygenerowany przez narzędzie.
//     Wersja wykonawcza:4.0.30319.42000
//
//     Zmiany w tym pliku mogą spowodować nieprawidłowe zachowanie i zostaną utracone, jeśli
//     kod zostanie ponownie wygenerowany.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Szafiarka.Classes
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="database")]
	public partial class MapDBDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertCategory(Category instance);
    partial void UpdateCategory(Category instance);
    partial void DeleteCategory(Category instance);
    partial void InsertWardrobe(Wardrobe instance);
    partial void UpdateWardrobe(Wardrobe instance);
    partial void DeleteWardrobe(Wardrobe instance);
    partial void Insertitem(item instance);
    partial void Updateitem(item instance);
    partial void Deleteitem(item instance);
    partial void InsertRoom(Room instance);
    partial void UpdateRoom(Room instance);
    partial void DeleteRoom(Room instance);
    partial void InsertShelf(Shelf instance);
    partial void UpdateShelf(Shelf instance);
    partial void DeleteShelf(Shelf instance);
    partial void InsertStatus(Status instance);
    partial void UpdateStatus(Status instance);
    partial void DeleteStatus(Status instance);
    #endregion
		
		public MapDBDataContext() : 
				base(global::Szafiarka.Properties.Settings.Default.databaseConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public MapDBDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public MapDBDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public MapDBDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public MapDBDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Category> Category
		{
			get
			{
				return this.GetTable<Category>();
			}
		}
		
		public System.Data.Linq.Table<Wardrobe> Wardrobe
		{
			get
			{
				return this.GetTable<Wardrobe>();
			}
		}
		
		public System.Data.Linq.Table<item> item
		{
			get
			{
				return this.GetTable<item>();
			}
		}
		
		public System.Data.Linq.Table<Room> Room
		{
			get
			{
				return this.GetTable<Room>();
			}
		}
		
		public System.Data.Linq.Table<Shelf> Shelf
		{
			get
			{
				return this.GetTable<Shelf>();
			}
		}
		
		public System.Data.Linq.Table<Status> Status
		{
			get
			{
				return this.GetTable<Status>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Category")]
	public partial class Category : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id_category;
		
		private string _name;
		
		private string _description;
		
		private EntitySet<item> _item;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void Onid_categoryChanging(int value);
    partial void Onid_categoryChanged();
    partial void OnnameChanging(string value);
    partial void OnnameChanged();
    partial void OndescriptionChanging(string value);
    partial void OndescriptionChanged();
    #endregion
		
		public Category()
		{
			this._item = new EntitySet<item>(new Action<item>(this.attach_item), new Action<item>(this.detach_item));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id_category", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int id_category
		{
			get
			{
				return this._id_category;
			}
			set
			{
				if ((this._id_category != value))
				{
					this.Onid_categoryChanging(value);
					this.SendPropertyChanging();
					this._id_category = value;
					this.SendPropertyChanged("id_category");
					this.Onid_categoryChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_name", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string name
		{
			get
			{
				return this._name;
			}
			set
			{
				if ((this._name != value))
				{
					this.OnnameChanging(value);
					this.SendPropertyChanging();
					this._name = value;
					this.SendPropertyChanged("name");
					this.OnnameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_description", DbType="Text", UpdateCheck=UpdateCheck.Never)]
		public string description
		{
			get
			{
				return this._description;
			}
			set
			{
				if ((this._description != value))
				{
					this.OndescriptionChanging(value);
					this.SendPropertyChanging();
					this._description = value;
					this.SendPropertyChanged("description");
					this.OndescriptionChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Category_item", Storage="_item", ThisKey="id_category", OtherKey="id_category")]
		public EntitySet<item> item
		{
			get
			{
				return this._item;
			}
			set
			{
				this._item.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_item(item entity)
		{
			this.SendPropertyChanging();
			entity.Category = this;
		}
		
		private void detach_item(item entity)
		{
			this.SendPropertyChanging();
			entity.Category = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Wardrobe")]
	public partial class Wardrobe : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id_wardrobe;
		
		private int _id_room;
		
		private string _name;
		
		private EntitySet<Shelf> _Shelf;
		
		private EntityRef<Room> _Room;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void Onid_wardrobeChanging(int value);
    partial void Onid_wardrobeChanged();
    partial void Onid_roomChanging(int value);
    partial void Onid_roomChanged();
    partial void OnnameChanging(string value);
    partial void OnnameChanged();
    #endregion
		
		public Wardrobe()
		{
			this._Shelf = new EntitySet<Shelf>(new Action<Shelf>(this.attach_Shelf), new Action<Shelf>(this.detach_Shelf));
			this._Room = default(EntityRef<Room>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id_wardrobe", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int id_wardrobe
		{
			get
			{
				return this._id_wardrobe;
			}
			set
			{
				if ((this._id_wardrobe != value))
				{
					this.Onid_wardrobeChanging(value);
					this.SendPropertyChanging();
					this._id_wardrobe = value;
					this.SendPropertyChanged("id_wardrobe");
					this.Onid_wardrobeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id_room", DbType="Int NOT NULL")]
		public int id_room
		{
			get
			{
				return this._id_room;
			}
			set
			{
				if ((this._id_room != value))
				{
					if (this._Room.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.Onid_roomChanging(value);
					this.SendPropertyChanging();
					this._id_room = value;
					this.SendPropertyChanged("id_room");
					this.Onid_roomChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_name", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string name
		{
			get
			{
				return this._name;
			}
			set
			{
				if ((this._name != value))
				{
					this.OnnameChanging(value);
					this.SendPropertyChanging();
					this._name = value;
					this.SendPropertyChanged("name");
					this.OnnameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Wardrobe_Shelf", Storage="_Shelf", ThisKey="id_wardrobe", OtherKey="id_wardrobe")]
		public EntitySet<Shelf> Shelf
		{
			get
			{
				return this._Shelf;
			}
			set
			{
				this._Shelf.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Room_Wardrobe", Storage="_Room", ThisKey="id_room", OtherKey="id_room", IsForeignKey=true)]
		public Room Room
		{
			get
			{
				return this._Room.Entity;
			}
			set
			{
				Room previousValue = this._Room.Entity;
				if (((previousValue != value) 
							|| (this._Room.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Room.Entity = null;
						previousValue.Wardrobe.Remove(this);
					}
					this._Room.Entity = value;
					if ((value != null))
					{
						value.Wardrobe.Add(this);
						this._id_room = value.id_room;
					}
					else
					{
						this._id_room = default(int);
					}
					this.SendPropertyChanged("Room");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Shelf(Shelf entity)
		{
			this.SendPropertyChanging();
			entity.Wardrobe = this;
		}
		
		private void detach_Shelf(Shelf entity)
		{
			this.SendPropertyChanging();
			entity.Wardrobe = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.item")]
	public partial class item : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id_item;
		
		private int _id_shelf;
		
		private int _id_status;
		
		private int _id_category;
		
		private string _name;
		
		private string _description;
		
		private int _size;
		
		private System.Data.Linq.Binary _image;
		
		private System.DateTime _create_date;
		
		private EntityRef<Category> _Category;
		
		private EntityRef<Shelf> _Shelf;
		
		private EntityRef<Status> _Status;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void Onid_itemChanging(int value);
    partial void Onid_itemChanged();
    partial void Onid_shelfChanging(int value);
    partial void Onid_shelfChanged();
    partial void Onid_statusChanging(int value);
    partial void Onid_statusChanged();
    partial void Onid_categoryChanging(int value);
    partial void Onid_categoryChanged();
    partial void OnnameChanging(string value);
    partial void OnnameChanged();
    partial void OndescriptionChanging(string value);
    partial void OndescriptionChanged();
    partial void OnsizeChanging(int value);
    partial void OnsizeChanged();
    partial void OnimageChanging(System.Data.Linq.Binary value);
    partial void OnimageChanged();
    partial void Oncreate_dateChanging(System.DateTime value);
    partial void Oncreate_dateChanged();
    #endregion
		
		public item()
		{
			this._Category = default(EntityRef<Category>);
			this._Shelf = default(EntityRef<Shelf>);
			this._Status = default(EntityRef<Status>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id_item", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int id_item
		{
			get
			{
				return this._id_item;
			}
			set
			{
				if ((this._id_item != value))
				{
					this.Onid_itemChanging(value);
					this.SendPropertyChanging();
					this._id_item = value;
					this.SendPropertyChanged("id_item");
					this.Onid_itemChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id_shelf", DbType="Int NOT NULL")]
		public int id_shelf
		{
			get
			{
				return this._id_shelf;
			}
			set
			{
				if ((this._id_shelf != value))
				{
					if (this._Shelf.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.Onid_shelfChanging(value);
					this.SendPropertyChanging();
					this._id_shelf = value;
					this.SendPropertyChanged("id_shelf");
					this.Onid_shelfChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id_status", DbType="Int NOT NULL")]
		public int id_status
		{
			get
			{
				return this._id_status;
			}
			set
			{
				if ((this._id_status != value))
				{
					if (this._Status.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.Onid_statusChanging(value);
					this.SendPropertyChanging();
					this._id_status = value;
					this.SendPropertyChanged("id_status");
					this.Onid_statusChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id_category", DbType="Int NOT NULL")]
		public int id_category
		{
			get
			{
				return this._id_category;
			}
			set
			{
				if ((this._id_category != value))
				{
					if (this._Category.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.Onid_categoryChanging(value);
					this.SendPropertyChanging();
					this._id_category = value;
					this.SendPropertyChanged("id_category");
					this.Onid_categoryChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_name", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string name
		{
			get
			{
				return this._name;
			}
			set
			{
				if ((this._name != value))
				{
					this.OnnameChanging(value);
					this.SendPropertyChanging();
					this._name = value;
					this.SendPropertyChanged("name");
					this.OnnameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_description", DbType="Text", UpdateCheck=UpdateCheck.Never)]
		public string description
		{
			get
			{
				return this._description;
			}
			set
			{
				if ((this._description != value))
				{
					this.OndescriptionChanging(value);
					this.SendPropertyChanging();
					this._description = value;
					this.SendPropertyChanged("description");
					this.OndescriptionChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_size", DbType="Int NOT NULL")]
		public int size
		{
			get
			{
				return this._size;
			}
			set
			{
				if ((this._size != value))
				{
					this.OnsizeChanging(value);
					this.SendPropertyChanging();
					this._size = value;
					this.SendPropertyChanged("size");
					this.OnsizeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_image", DbType="Image", UpdateCheck=UpdateCheck.Never)]
		public System.Data.Linq.Binary image
		{
			get
			{
				return this._image;
			}
			set
			{
				if ((this._image != value))
				{
					this.OnimageChanging(value);
					this.SendPropertyChanging();
					this._image = value;
					this.SendPropertyChanged("image");
					this.OnimageChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_create_date", DbType="Date NOT NULL")]
		public System.DateTime create_date
		{
			get
			{
				return this._create_date;
			}
			set
			{
				if ((this._create_date != value))
				{
					this.Oncreate_dateChanging(value);
					this.SendPropertyChanging();
					this._create_date = value;
					this.SendPropertyChanged("create_date");
					this.Oncreate_dateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Category_item", Storage="_Category", ThisKey="id_category", OtherKey="id_category", IsForeignKey=true)]
		public Category Category
		{
			get
			{
				return this._Category.Entity;
			}
			set
			{
				Category previousValue = this._Category.Entity;
				if (((previousValue != value) 
							|| (this._Category.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Category.Entity = null;
						previousValue.item.Remove(this);
					}
					this._Category.Entity = value;
					if ((value != null))
					{
						value.item.Add(this);
						this._id_category = value.id_category;
					}
					else
					{
						this._id_category = default(int);
					}
					this.SendPropertyChanged("Category");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Shelf_item", Storage="_Shelf", ThisKey="id_shelf", OtherKey="id_shelf", IsForeignKey=true)]
		public Shelf Shelf
		{
			get
			{
				return this._Shelf.Entity;
			}
			set
			{
				Shelf previousValue = this._Shelf.Entity;
				if (((previousValue != value) 
							|| (this._Shelf.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Shelf.Entity = null;
						previousValue.item.Remove(this);
					}
					this._Shelf.Entity = value;
					if ((value != null))
					{
						value.item.Add(this);
						this._id_shelf = value.id_shelf;
					}
					else
					{
						this._id_shelf = default(int);
					}
					this.SendPropertyChanged("Shelf");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Status_item", Storage="_Status", ThisKey="id_status", OtherKey="id_status", IsForeignKey=true)]
		public Status Status
		{
			get
			{
				return this._Status.Entity;
			}
			set
			{
				Status previousValue = this._Status.Entity;
				if (((previousValue != value) 
							|| (this._Status.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Status.Entity = null;
						previousValue.item.Remove(this);
					}
					this._Status.Entity = value;
					if ((value != null))
					{
						value.item.Add(this);
						this._id_status = value.id_status;
					}
					else
					{
						this._id_status = default(int);
					}
					this.SendPropertyChanged("Status");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Room")]
	public partial class Room : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id_room;
		
		private string _name;
		
		private EntitySet<Wardrobe> _Wardrobe;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void Onid_roomChanging(int value);
    partial void Onid_roomChanged();
    partial void OnnameChanging(string value);
    partial void OnnameChanged();
    #endregion
		
		public Room()
		{
			this._Wardrobe = new EntitySet<Wardrobe>(new Action<Wardrobe>(this.attach_Wardrobe), new Action<Wardrobe>(this.detach_Wardrobe));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id_room", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int id_room
		{
			get
			{
				return this._id_room;
			}
			set
			{
				if ((this._id_room != value))
				{
					this.Onid_roomChanging(value);
					this.SendPropertyChanging();
					this._id_room = value;
					this.SendPropertyChanged("id_room");
					this.Onid_roomChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_name", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string name
		{
			get
			{
				return this._name;
			}
			set
			{
				if ((this._name != value))
				{
					this.OnnameChanging(value);
					this.SendPropertyChanging();
					this._name = value;
					this.SendPropertyChanged("name");
					this.OnnameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Room_Wardrobe", Storage="_Wardrobe", ThisKey="id_room", OtherKey="id_room")]
		public EntitySet<Wardrobe> Wardrobe
		{
			get
			{
				return this._Wardrobe;
			}
			set
			{
				this._Wardrobe.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Wardrobe(Wardrobe entity)
		{
			this.SendPropertyChanging();
			entity.Room = this;
		}
		
		private void detach_Wardrobe(Wardrobe entity)
		{
			this.SendPropertyChanging();
			entity.Room = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Shelf")]
	public partial class Shelf : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id_shelf;
		
		private int _id_wardrobe;
		
		private int _location;
		
		private int _capacity;
		
		private EntitySet<item> _item;
		
		private EntityRef<Wardrobe> _Wardrobe;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void Onid_shelfChanging(int value);
    partial void Onid_shelfChanged();
    partial void Onid_wardrobeChanging(int value);
    partial void Onid_wardrobeChanged();
    partial void OnlocationChanging(int value);
    partial void OnlocationChanged();
    partial void OncapacityChanging(int value);
    partial void OncapacityChanged();
    #endregion
		
		public Shelf()
		{
			this._item = new EntitySet<item>(new Action<item>(this.attach_item), new Action<item>(this.detach_item));
			this._Wardrobe = default(EntityRef<Wardrobe>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id_shelf", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int id_shelf
		{
			get
			{
				return this._id_shelf;
			}
			set
			{
				if ((this._id_shelf != value))
				{
					this.Onid_shelfChanging(value);
					this.SendPropertyChanging();
					this._id_shelf = value;
					this.SendPropertyChanged("id_shelf");
					this.Onid_shelfChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id_wardrobe", DbType="Int NOT NULL")]
		public int id_wardrobe
		{
			get
			{
				return this._id_wardrobe;
			}
			set
			{
				if ((this._id_wardrobe != value))
				{
					if (this._Wardrobe.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.Onid_wardrobeChanging(value);
					this.SendPropertyChanging();
					this._id_wardrobe = value;
					this.SendPropertyChanged("id_wardrobe");
					this.Onid_wardrobeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_location", DbType="Int NOT NULL")]
		public int location
		{
			get
			{
				return this._location;
			}
			set
			{
				if ((this._location != value))
				{
					this.OnlocationChanging(value);
					this.SendPropertyChanging();
					this._location = value;
					this.SendPropertyChanged("location");
					this.OnlocationChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_capacity", DbType="Int NOT NULL")]
		public int capacity
		{
			get
			{
				return this._capacity;
			}
			set
			{
				if ((this._capacity != value))
				{
					this.OncapacityChanging(value);
					this.SendPropertyChanging();
					this._capacity = value;
					this.SendPropertyChanged("capacity");
					this.OncapacityChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Shelf_item", Storage="_item", ThisKey="id_shelf", OtherKey="id_shelf")]
		public EntitySet<item> item
		{
			get
			{
				return this._item;
			}
			set
			{
				this._item.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Wardrobe_Shelf", Storage="_Wardrobe", ThisKey="id_wardrobe", OtherKey="id_wardrobe", IsForeignKey=true)]
		public Wardrobe Wardrobe
		{
			get
			{
				return this._Wardrobe.Entity;
			}
			set
			{
				Wardrobe previousValue = this._Wardrobe.Entity;
				if (((previousValue != value) 
							|| (this._Wardrobe.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Wardrobe.Entity = null;
						previousValue.Shelf.Remove(this);
					}
					this._Wardrobe.Entity = value;
					if ((value != null))
					{
						value.Shelf.Add(this);
						this._id_wardrobe = value.id_wardrobe;
					}
					else
					{
						this._id_wardrobe = default(int);
					}
					this.SendPropertyChanged("Wardrobe");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_item(item entity)
		{
			this.SendPropertyChanging();
			entity.Shelf = this;
		}
		
		private void detach_item(item entity)
		{
			this.SendPropertyChanging();
			entity.Shelf = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Status")]
	public partial class Status : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id_status;
		
		private string _name;
		
		private EntitySet<item> _item;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void Onid_statusChanging(int value);
    partial void Onid_statusChanged();
    partial void OnnameChanging(string value);
    partial void OnnameChanged();
    #endregion
		
		public Status()
		{
			this._item = new EntitySet<item>(new Action<item>(this.attach_item), new Action<item>(this.detach_item));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id_status", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int id_status
		{
			get
			{
				return this._id_status;
			}
			set
			{
				if ((this._id_status != value))
				{
					this.Onid_statusChanging(value);
					this.SendPropertyChanging();
					this._id_status = value;
					this.SendPropertyChanged("id_status");
					this.Onid_statusChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_name", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string name
		{
			get
			{
				return this._name;
			}
			set
			{
				if ((this._name != value))
				{
					this.OnnameChanging(value);
					this.SendPropertyChanging();
					this._name = value;
					this.SendPropertyChanged("name");
					this.OnnameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Status_item", Storage="_item", ThisKey="id_status", OtherKey="id_status")]
		public EntitySet<item> item
		{
			get
			{
				return this._item;
			}
			set
			{
				this._item.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_item(item entity)
		{
			this.SendPropertyChanging();
			entity.Status = this;
		}
		
		private void detach_item(item entity)
		{
			this.SendPropertyChanging();
			entity.Status = null;
		}
	}
}
#pragma warning restore 1591
