package androidx.work.impl.model;

import androidx.sqlite.db.SupportSQLiteQuery;
import androidx.work.WorkInfo;
import com.scanflow.datacapture.barinternal.kotlinx.coroutines.CoroutineDispatcher;
import java.util.List;
import kotlin.jvm.internal.Intrinsics;
import kotlinx.coroutines.flow.Flow;

/* JADX INFO: compiled from: RawWorkInfoDao.kt */
/* JADX INFO: loaded from: classes.dex */
public final class RawWorkInfoDaoKt {
    public static final Flow<List<WorkInfo>> getWorkInfoPojosFlow(RawWorkInfoDao rawWorkInfoDao, CoroutineDispatcher dispatcher, SupportSQLiteQuery query) {
        Intrinsics.checkNotNullParameter(rawWorkInfoDao, "<this>");
        Intrinsics.checkNotNullParameter(dispatcher, "dispatcher");
        Intrinsics.checkNotNullParameter(query, "query");
        return WorkSpecDaoKt.dedup(rawWorkInfoDao.getWorkInfoPojosFlow(query), dispatcher);
    }
}
