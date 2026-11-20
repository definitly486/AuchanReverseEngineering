package com.scanflow.datacapture.barcode;

import android.util.SparseIntArray;
import android.view.View;
import androidx.databinding.DataBinderMapper;
import androidx.databinding.ViewDataBinding;
import com.scanflow.datacapture.barinternal.AbstractC0091i;
import com.scanflow.datacapture.barinternal.AbstractC0092j;
import com.scanflow.datacapture.barinternal.InterfaceC0093k;
import java.util.ArrayList;
import java.util.List;

/* JADX INFO: loaded from: classes3.dex */
public class DataBinderMapperImpl extends DataBinderMapper {
    public static final SparseIntArray a = new SparseIntArray(0);

    public final ViewDataBinding a(InterfaceC0093k interfaceC0093k, View view, int i) {
        if (a.get(i) <= 0 || view.getTag() != null) {
            return null;
        }
        throw new RuntimeException("view must have a tag");
    }

    public final List collectDependencies() {
        ArrayList arrayList = new ArrayList(1);
        arrayList.add(new androidx.databinding.library.baseAdapters.DataBinderMapperImpl());
        return arrayList;
    }

    public final String convertBrIdToString(int i) {
        return (String) AbstractC0091i.a.get(i);
    }

    public final int getLayoutId(String str) {
        Integer num;
        if (str == null || (num = (Integer) AbstractC0092j.a.get(str)) == null) {
            return 0;
        }
        return num.intValue();
    }

    public final ViewDataBinding a(InterfaceC0093k interfaceC0093k, View[] viewArr, int i) {
        if (viewArr == null || viewArr.length == 0 || a.get(i) <= 0 || viewArr[0].getTag() != null) {
            return null;
        }
        throw new RuntimeException("view must have a tag");
    }
}
