CREATE DATABASE ePahal
ON
(NAME=ePahal_data,
	FILENAME='D:\SQLServerDB\Epahal\ePahal.mdf')
LOG ON
(NAME=ePahal_log,
	FILENAME='D:\SQLServerDB\Epahal\ePahal.ldf')

USE ePahal;

CREATE TABLE user_info
(
	user_id varchar(5) CONSTRAINT pk_user_id PRIMARY KEY,
	user_fname varchar(20) not null,
	user_mname varchar(20),
	user_lname varchar(20) not null,
	user_gender varchar(10),
	user_martial_status varchar(15),
	user_contact_address varchar(100),
	user_citizenship_passport_no varchar (25),
	user_issue_date_ad datetime,
	user_issue_date_bs varchar(20),
	user_issue_place varchar (100),
	user_department varchar(50),
	user_position varchar (50),
	user_contact_no1 varchar(15),
	user_contact_no2 varchar(15),
	user_contact_no3 varchar(15),
	user_email1 varchar(30),
	user_email2 varchar(30),
	user_login_name varchar(15) not null unique,
	user_login_pwd varchar(25),
	user_createby varchar (5),
	user_create_date datetime,
	user_updateby varchar (5),
	user_update_date datetime,
	user_activateby varchar (5),
	user_activate_date datetime,
	user_deactivateby varchar (5),
	user_deactivate_date datetime,
	user_photo image,
	user_active_status bit not null default 1,
	user_drop_status bit not null default 0
);

--NOTE CREATE TWO USER ONE WITH ID ADMIN AND ANOTHER WITH LOGIN ADMIN
--CREATING ADMINISTRATOR AND ADMIN USER
INSERT INTO user_info(user_id,user_fname,user_mname,user_lname,user_gender,user_martial_status,user_contact_address,user_citizenship_passport_no,user_issue_date_ad,user_issue_date_bs,user_issue_place,user_department,user_position,user_contact_no1,user_contact_no2,user_contact_no3,user_email1,user_email2,user_login_name,user_login_pwd,user_createby,user_create_date,user_activateby,user_activate_date) VALUES('Admin', 'FirstName', 'MiddleName','LastName', 'Gender','MartialStatus','ContactAddress','CitizenshipPassport','2016/09/17','2016/09/17','IssuePlace','Department','Position','ContactNo1','ContactNo2','ContactNo3','Email1','Email2','Admin','Admin', 'Admin','2016/09/17','Admin','2016/09/17');
INSERT INTO user_info(user_id,user_fname,user_mname,user_lname,user_gender,user_martial_status,user_contact_address,user_citizenship_passport_no,user_issue_date_ad,user_issue_date_bs,user_issue_place,user_department,user_position,user_contact_no1,user_contact_no2,user_contact_no3,user_email1,user_email2,user_login_name,user_login_pwd,user_createby,user_create_date,user_activateby,user_activate_date) VALUES('U0001', 'FirstName', 'MiddleName','LastName', 'Gender','MartialStatus','ContactAddress','CitizenshipPassport','2016/09/17','2016/09/17','IssuePlace','Department','Position','ContactNo1','ContactNo2','ContactNo3','Email1','Email2','epahal','epahal', 'Admin','2016/09/17','Admin','2016/09/17');


CREATE TABLE EPahal_Client
(		
	formID varchar(5) not null  PRIMARY KEY,
	organization_name varchar(250),
	organization_address varchar(Max),
	organization_district varchar(50),
	organization_phone varchar(20),
	organization_first_persion varchar(50),
	organization_first_persion_mobile varchar(20),
	contact_person varchar(50),
	contact_person_moble varchar(20),	
	feedback varchar(Max),
	remarks varchar(Max),
	refered_by varchar(250),
	reg_date datetime,
	reg_ndate varchar (15),
	CreateBy varchar(5) CONSTRAINT fk_Client_CreateBy FOREIGN KEY  references user_info(user_id),
	CreateDate datetime,
	UpdateBy varchar(5) CONSTRAINT fk_Client_UpdateBy FOREIGN KEY  references user_info(user_id),
	UpdateDate datetime,
	DeletedBy varchar(5) CONSTRAINT fk_Client_DropBy FOREIGN KEY  references user_info(user_id),
	DeleteDate datetime,
	ActivateBy varchar(5) CONSTRAINT fk_Client_ActivateBy FOREIGN KEY  references user_info(user_id),
	ActivateDate datetime,
	DeactivateBy varchar(5) CONSTRAINT fk_Client_DeactivateBy FOREIGN KEY  references user_info(user_id),
	DeactivateDate datetime,
	estatus bit not null default 1	
);

SELECT * FROM EPahal_Client
CREATE TABLE EPahal_Subscription
(
	Subs_ID varchar(5) not null  PRIMARY KEY,
	Client_ID varchar(5) CONSTRAINT fk_Client_ID FOREIGN KEY  references EPahal_Client(formID),
	Invoice_no varchar(20),		
	receipt_no varchar(20) not null,
	service_email varchar(20),
	notice_type_supply varchar(20),
	notice_type_construction varchar(20),
	notice_type_consultancy varchar(20),
	service_start_date datetime,
	service_start_ndate varchar (15),
	service_period varchar(15),
	service_expire_date datetime,
	service_expire_ndate varchar(15),
	receive_amount money,
	receive_amount_date datetime,
	receive_amount_ndate varchar(15),
	cash varchar(10),
	cheque_no varchar(30),
	deposite_by varchar(50),
	bank_name varchar(50),
	received_by varchar(50),
	sub_type varchar(10),
	sub_status bit not null default 1,
	checked_by varchar(150),
	CreateBy varchar(5) CONSTRAINT fk_Subs_CreateBy FOREIGN KEY  references user_info(user_id),
	CreateDate datetime,
	UpdateBy varchar(5) CONSTRAINT fk_Subs_UpdateBy FOREIGN KEY  references user_info(user_id),
	UpdateDate datetime,
	DeletedBy varchar(5) CONSTRAINT fk_Subs_DropBy FOREIGN KEY  references user_info(user_id),
	DeleteDate datetime,
	VerifiedBy varchar(5) CONSTRAINT fk_Subs_VerifiedBy FOREIGN KEY  references user_info(user_id),
	VerifiedDate datetime,
	sub_dstatus bit not null default 1	
);



select * from EPahal_Subscription

