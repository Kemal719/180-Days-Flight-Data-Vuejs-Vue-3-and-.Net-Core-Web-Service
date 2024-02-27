export enum AlignType {
	Left,
	Right,
	Center,
}

export interface ColumnHeaderType {
	align: AlignType;
}

export enum ColumnDataTypeEnum {
	Text,
	Number,
	Boolean,
	DateTime,
	BooleanCheckbox,
	Template,
	Custom,
}

export interface BooleanColumnDataType {
	trueText: string;
	falseText: string;
}

export class DefaultBooleanColumnDataType implements BooleanColumnDataType {
	public trueText = "Evet";
	public falseText = "Hayır";
}

export interface DateTimeColumnDataType {
	importFormat: string;
	exportFormat: string;
}

// eslint-disable-next-line vue/no-export-in-script-setup
export class DefaultDateTimeColumnDataType implements DateTimeColumnDataType {
	public importFormat = "YYYY/MM/DD";
	public exportFormat = "DD.MM.YYYY";
}

export interface ColumnDataType {
	align?: AlignType;
	type?: ColumnDataTypeEnum;
	booleanColumn?: BooleanColumnDataType;
	dateTimeColumn?: DateTimeColumnDataType;
	customComponentName?: string;
}

export interface ColumnType {
	columnName?: string;
	fieldName: string;
	title: string;
	header?: ColumnHeaderType;
	data?: ColumnDataType;
}

export enum PagerType {
	SimplePager,
	DropDownPager,
	Custom,
}

export interface local {
	id: number;
	havaAlaniAdi: string;
	havaAlaniVaris: string;
	kalkisSaati: string;
	varisSaati: string;
	havaYoluSirketi: string;
	ucusNo: string;
	ucusDurumu: boolean;
	tarih: string;
}

export type DataRow = Record<string, any>;

export interface DataSource {
	local: DataRow[];
}

export interface FilterItem {
	column: ColumnType;
}