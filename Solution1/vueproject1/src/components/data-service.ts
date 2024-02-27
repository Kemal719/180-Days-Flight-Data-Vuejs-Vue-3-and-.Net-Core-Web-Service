import { DataRow, DataSource } from "./types";
import { ref } from "vue";

export class DataService {
  constructor(public dataSource: DataRow[] | undefined | null = null) {
    this.dataSource = dataSource;
  }

  public pageSize = ref(1);
  public pageIndex = ref(1);
  public totalRowCount = 0;

  public getPageData = (
    newPageSize: number,
    newpageIndex: number
  ): DataRow[] => {
    if (this.dataSource && this.dataSource.length) {
      this.totalRowCount = 180 / this.pageSize.value;
      return this.getPagedData(this.dataSource, newPageSize, newpageIndex);
    }

    return [];
  };

  private getPagedData = (
    rows: DataRow[],
    newPageSize: number,
    newpageIndex: number
  ): DataRow[] => {
    if (rows && rows.length) {
      this.pageSize.value = newPageSize;

      const startIndex = ref(0);
      const finishIndex = ref(0);

      if (newPageSize != 0) {
        if (newpageIndex == 0) {
          startIndex.value = (this.pageIndex.value - 1) * newPageSize;
          finishIndex.value = startIndex.value + newPageSize;
        } else {
          startIndex.value = (newpageIndex - 1) * newPageSize;
          finishIndex.value = startIndex.value + newPageSize;
          this.pageIndex.value = newpageIndex;
        }

        console.log(
          "Start: 1 " +
            this.pageIndex.value +
            " Finishindex: 1 " +
            this.pageSize.value
        );

        if (newPageSize >= rows.length) {
          return rows;
        } else {
          return rows.filter(
            (_, index) => index >= startIndex.value && index < finishIndex.value
          );
        }
      } else {
        if (newpageIndex == 0) {
          startIndex.value = (this.pageIndex.value - 1) * this.pageSize.value;
          finishIndex.value = startIndex.value + this.pageSize.value;
        } else {
          startIndex.value = (newpageIndex - 1) * this.pageSize.value;
          finishIndex.value = startIndex.value + this.pageSize.value;
          this.pageIndex.value = newpageIndex;
        }

        console.log(
          "Start: 2 " +
            this.pageIndex.value +
            " Finishindex: 2 " +
            this.pageSize.value
        );

        if (this.pageSize.value >= rows.length) {
          return rows;
        } else {
          return rows.filter(
            (_, index) => index >= startIndex.value && index < finishIndex.value
          );
        }
      }
    }

    return [];
  };
}
