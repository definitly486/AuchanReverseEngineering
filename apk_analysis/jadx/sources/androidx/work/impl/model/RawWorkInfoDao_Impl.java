package androidx.work.impl.model;

import android.database.Cursor;
import androidx.lifecycle.LiveData;
import androidx.room.CoroutinesRoom;
import androidx.room.RoomDatabase;
import androidx.room.RoomSQLiteQuery;
import androidx.room.util.CursorUtil;
import androidx.room.util.DBUtil;
import androidx.room.util.RelationUtil;
import androidx.room.util.StringUtil;
import androidx.sqlite.db.SupportSQLiteQuery;
import androidx.work.BackoffPolicy;
import androidx.work.Constraints;
import androidx.work.Data;
import androidx.work.NetworkType;
import androidx.work.WorkInfo;
import androidx.work.impl.utils.NetworkRequestCompat;
import com.scanflow.datacapture.barinternal.kotlin.Unit;
import java.util.ArrayList;
import java.util.Collections;
import java.util.HashMap;
import java.util.Iterator;
import java.util.List;
import java.util.Set;
import java.util.concurrent.Callable;
import kotlin.jvm.functions.Function1;
import kotlinx.coroutines.flow.Flow;

/* JADX INFO: loaded from: classes.dex */
public final class RawWorkInfoDao_Impl implements RawWorkInfoDao {
    private final RoomDatabase __db;

    public RawWorkInfoDao_Impl(RoomDatabase roomDatabase) {
        this.__db = roomDatabase;
    }

    @Override // androidx.work.impl.model.RawWorkInfoDao
    public List<WorkSpec.WorkInfoPojo> getWorkInfoPojos(SupportSQLiteQuery supportSQLiteQuery) {
        boolean z;
        boolean z2;
        boolean z3;
        this.__db.assertNotSuspendingTransaction();
        Cursor cursorQuery = DBUtil.query(this.__db, supportSQLiteQuery, true, null);
        try {
            int columnIndex = CursorUtil.getColumnIndex(cursorQuery, "id");
            int columnIndex2 = CursorUtil.getColumnIndex(cursorQuery, "state");
            int columnIndex3 = CursorUtil.getColumnIndex(cursorQuery, "output");
            int columnIndex4 = CursorUtil.getColumnIndex(cursorQuery, "initial_delay");
            int columnIndex5 = CursorUtil.getColumnIndex(cursorQuery, "interval_duration");
            int columnIndex6 = CursorUtil.getColumnIndex(cursorQuery, "flex_duration");
            int columnIndex7 = CursorUtil.getColumnIndex(cursorQuery, "run_attempt_count");
            int columnIndex8 = CursorUtil.getColumnIndex(cursorQuery, "backoff_policy");
            int columnIndex9 = CursorUtil.getColumnIndex(cursorQuery, "backoff_delay_duration");
            int columnIndex10 = CursorUtil.getColumnIndex(cursorQuery, "last_enqueue_time");
            int columnIndex11 = CursorUtil.getColumnIndex(cursorQuery, "period_count");
            int columnIndex12 = CursorUtil.getColumnIndex(cursorQuery, "generation");
            int columnIndex13 = CursorUtil.getColumnIndex(cursorQuery, "next_schedule_time_override");
            int columnIndex14 = CursorUtil.getColumnIndex(cursorQuery, "stop_reason");
            int columnIndex15 = CursorUtil.getColumnIndex(cursorQuery, "required_network_type");
            int columnIndex16 = CursorUtil.getColumnIndex(cursorQuery, "required_network_request");
            int columnIndex17 = CursorUtil.getColumnIndex(cursorQuery, "requires_charging");
            int columnIndex18 = CursorUtil.getColumnIndex(cursorQuery, "requires_device_idle");
            int columnIndex19 = CursorUtil.getColumnIndex(cursorQuery, "requires_battery_not_low");
            int columnIndex20 = CursorUtil.getColumnIndex(cursorQuery, "requires_storage_not_low");
            int columnIndex21 = CursorUtil.getColumnIndex(cursorQuery, "trigger_content_update_delay");
            int columnIndex22 = CursorUtil.getColumnIndex(cursorQuery, "trigger_max_content_delay");
            int columnIndex23 = CursorUtil.getColumnIndex(cursorQuery, "content_uri_triggers");
            HashMap<String, ArrayList<String>> map = new HashMap<>();
            int i = columnIndex13;
            HashMap<String, ArrayList<Data>> map2 = new HashMap<>();
            while (cursorQuery.moveToNext()) {
                int i2 = columnIndex12;
                String string = cursorQuery.getString(columnIndex);
                if (!map.containsKey(string)) {
                    map.put(string, new ArrayList<>());
                }
                String string2 = cursorQuery.getString(columnIndex);
                if (!map2.containsKey(string2)) {
                    map2.put(string2, new ArrayList<>());
                }
                columnIndex12 = i2;
                columnIndex11 = columnIndex11;
            }
            int i3 = columnIndex11;
            int i4 = columnIndex12;
            cursorQuery.moveToPosition(-1);
            __fetchRelationshipWorkTagAsjavaLangString(map);
            __fetchRelationshipWorkProgressAsandroidxWorkData(map2);
            ArrayList arrayList = new ArrayList(cursorQuery.getCount());
            while (cursorQuery.moveToNext()) {
                String string3 = columnIndex == -1 ? null : cursorQuery.getString(columnIndex);
                WorkInfo.State stateIntToState = columnIndex2 == -1 ? null : WorkTypeConverters.intToState(cursorQuery.getInt(columnIndex2));
                Data dataFromByteArray = columnIndex3 == -1 ? null : Data.fromByteArray(cursorQuery.getBlob(columnIndex3));
                long j = columnIndex4 == -1 ? 0L : cursorQuery.getLong(columnIndex4);
                long j2 = columnIndex5 == -1 ? 0L : cursorQuery.getLong(columnIndex5);
                long j3 = columnIndex6 == -1 ? 0L : cursorQuery.getLong(columnIndex6);
                boolean z4 = false;
                int i5 = columnIndex7 == -1 ? 0 : cursorQuery.getInt(columnIndex7);
                BackoffPolicy backoffPolicyIntToBackoffPolicy = columnIndex8 == -1 ? null : WorkTypeConverters.intToBackoffPolicy(cursorQuery.getInt(columnIndex8));
                long j4 = columnIndex9 == -1 ? 0L : cursorQuery.getLong(columnIndex9);
                long j5 = columnIndex10 == -1 ? 0L : cursorQuery.getLong(columnIndex10);
                int i6 = i3;
                int i7 = i6 == -1 ? 0 : cursorQuery.getInt(i6);
                i3 = i6;
                int i8 = i4;
                int i9 = i8 == -1 ? 0 : cursorQuery.getInt(i8);
                i4 = i8;
                int i10 = i;
                long j6 = i10 == -1 ? 0L : cursorQuery.getLong(i10);
                i = i10;
                int i11 = columnIndex14;
                int i12 = i11 == -1 ? 0 : cursorQuery.getInt(i11);
                columnIndex14 = i11;
                int i13 = columnIndex15;
                NetworkType networkTypeIntToNetworkType = i13 == -1 ? null : WorkTypeConverters.intToNetworkType(cursorQuery.getInt(i13));
                columnIndex15 = i13;
                int i14 = columnIndex16;
                NetworkRequestCompat networkRequest$work_runtime_release = i14 == -1 ? null : WorkTypeConverters.toNetworkRequest$work_runtime_release(cursorQuery.getBlob(i14));
                columnIndex16 = i14;
                int i15 = columnIndex17;
                if (i15 == -1) {
                    z = false;
                } else {
                    z = cursorQuery.getInt(i15) != 0;
                }
                columnIndex17 = i15;
                int i16 = columnIndex18;
                if (i16 == -1) {
                    z2 = false;
                } else {
                    z2 = cursorQuery.getInt(i16) != 0;
                }
                columnIndex18 = i16;
                int i17 = columnIndex19;
                if (i17 == -1) {
                    z3 = false;
                } else {
                    z3 = cursorQuery.getInt(i17) != 0;
                }
                columnIndex19 = i17;
                int i18 = columnIndex20;
                if (i18 != -1 && cursorQuery.getInt(i18) != 0) {
                    z4 = true;
                }
                columnIndex20 = i18;
                int i19 = columnIndex21;
                boolean z5 = z4;
                long j7 = i19 == -1 ? 0L : cursorQuery.getLong(i19);
                columnIndex21 = i19;
                int i20 = columnIndex22;
                long j8 = i20 != -1 ? cursorQuery.getLong(i20) : 0L;
                columnIndex22 = i20;
                int i21 = columnIndex23;
                columnIndex23 = i21;
                arrayList.add(new WorkSpec.WorkInfoPojo(string3, stateIntToState, dataFromByteArray, j, j2, j3, new Constraints(networkRequest$work_runtime_release, networkTypeIntToNetworkType, z, z2, z3, z5, j7, j8, i21 == -1 ? null : WorkTypeConverters.byteArrayToSetOfTriggers(cursorQuery.getBlob(i21))), i5, backoffPolicyIntToBackoffPolicy, j4, j5, i7, i9, j6, i12, map.get(cursorQuery.getString(columnIndex)), map2.get(cursorQuery.getString(columnIndex))));
            }
            return arrayList;
        } finally {
            cursorQuery.close();
        }
    }

    @Override // androidx.work.impl.model.RawWorkInfoDao
    public LiveData<List<WorkSpec.WorkInfoPojo>> getWorkInfoPojosLiveData(final SupportSQLiteQuery supportSQLiteQuery) {
        return this.__db.getInvalidationTracker().createLiveData(new String[]{"WorkTag", "WorkProgress", "WorkSpec"}, false, new Callable() { // from class: androidx.work.impl.model.RawWorkInfoDao_Impl.1
            @Override // java.util.concurrent.Callable
            public List call() {
                boolean z;
                boolean z2;
                boolean z3;
                Cursor cursorQuery = DBUtil.query(RawWorkInfoDao_Impl.this.__db, supportSQLiteQuery, true, null);
                try {
                    int columnIndex = CursorUtil.getColumnIndex(cursorQuery, "id");
                    int columnIndex2 = CursorUtil.getColumnIndex(cursorQuery, "state");
                    int columnIndex3 = CursorUtil.getColumnIndex(cursorQuery, "output");
                    int columnIndex4 = CursorUtil.getColumnIndex(cursorQuery, "initial_delay");
                    int columnIndex5 = CursorUtil.getColumnIndex(cursorQuery, "interval_duration");
                    int columnIndex6 = CursorUtil.getColumnIndex(cursorQuery, "flex_duration");
                    int columnIndex7 = CursorUtil.getColumnIndex(cursorQuery, "run_attempt_count");
                    int columnIndex8 = CursorUtil.getColumnIndex(cursorQuery, "backoff_policy");
                    int columnIndex9 = CursorUtil.getColumnIndex(cursorQuery, "backoff_delay_duration");
                    int columnIndex10 = CursorUtil.getColumnIndex(cursorQuery, "last_enqueue_time");
                    int columnIndex11 = CursorUtil.getColumnIndex(cursorQuery, "period_count");
                    int columnIndex12 = CursorUtil.getColumnIndex(cursorQuery, "generation");
                    int columnIndex13 = CursorUtil.getColumnIndex(cursorQuery, "next_schedule_time_override");
                    int columnIndex14 = CursorUtil.getColumnIndex(cursorQuery, "stop_reason");
                    int columnIndex15 = CursorUtil.getColumnIndex(cursorQuery, "required_network_type");
                    int columnIndex16 = CursorUtil.getColumnIndex(cursorQuery, "required_network_request");
                    int columnIndex17 = CursorUtil.getColumnIndex(cursorQuery, "requires_charging");
                    int columnIndex18 = CursorUtil.getColumnIndex(cursorQuery, "requires_device_idle");
                    int columnIndex19 = CursorUtil.getColumnIndex(cursorQuery, "requires_battery_not_low");
                    int columnIndex20 = CursorUtil.getColumnIndex(cursorQuery, "requires_storage_not_low");
                    int columnIndex21 = CursorUtil.getColumnIndex(cursorQuery, "trigger_content_update_delay");
                    int columnIndex22 = CursorUtil.getColumnIndex(cursorQuery, "trigger_max_content_delay");
                    int columnIndex23 = CursorUtil.getColumnIndex(cursorQuery, "content_uri_triggers");
                    HashMap map = new HashMap();
                    int i = columnIndex13;
                    HashMap map2 = new HashMap();
                    while (cursorQuery.moveToNext()) {
                        int i2 = columnIndex12;
                        String string = cursorQuery.getString(columnIndex);
                        if (!map.containsKey(string)) {
                            map.put(string, new ArrayList());
                        }
                        String string2 = cursorQuery.getString(columnIndex);
                        if (!map2.containsKey(string2)) {
                            map2.put(string2, new ArrayList());
                        }
                        columnIndex12 = i2;
                        columnIndex11 = columnIndex11;
                    }
                    int i3 = columnIndex11;
                    int i4 = columnIndex12;
                    cursorQuery.moveToPosition(-1);
                    RawWorkInfoDao_Impl.this.__fetchRelationshipWorkTagAsjavaLangString(map);
                    RawWorkInfoDao_Impl.this.__fetchRelationshipWorkProgressAsandroidxWorkData(map2);
                    ArrayList arrayList = new ArrayList(cursorQuery.getCount());
                    while (cursorQuery.moveToNext()) {
                        String string3 = columnIndex == -1 ? null : cursorQuery.getString(columnIndex);
                        WorkInfo.State stateIntToState = columnIndex2 == -1 ? null : WorkTypeConverters.intToState(cursorQuery.getInt(columnIndex2));
                        Data dataFromByteArray = columnIndex3 == -1 ? null : Data.fromByteArray(cursorQuery.getBlob(columnIndex3));
                        long j = columnIndex4 == -1 ? 0L : cursorQuery.getLong(columnIndex4);
                        long j2 = columnIndex5 == -1 ? 0L : cursorQuery.getLong(columnIndex5);
                        long j3 = columnIndex6 == -1 ? 0L : cursorQuery.getLong(columnIndex6);
                        boolean z4 = false;
                        int i5 = columnIndex7 == -1 ? 0 : cursorQuery.getInt(columnIndex7);
                        BackoffPolicy backoffPolicyIntToBackoffPolicy = columnIndex8 == -1 ? null : WorkTypeConverters.intToBackoffPolicy(cursorQuery.getInt(columnIndex8));
                        long j4 = columnIndex9 == -1 ? 0L : cursorQuery.getLong(columnIndex9);
                        long j5 = columnIndex10 == -1 ? 0L : cursorQuery.getLong(columnIndex10);
                        int i6 = i3;
                        int i7 = i6 == -1 ? 0 : cursorQuery.getInt(i6);
                        i3 = i6;
                        int i8 = i4;
                        int i9 = i8 == -1 ? 0 : cursorQuery.getInt(i8);
                        i4 = i8;
                        int i10 = i;
                        long j6 = i10 == -1 ? 0L : cursorQuery.getLong(i10);
                        i = i10;
                        int i11 = columnIndex14;
                        int i12 = i11 == -1 ? 0 : cursorQuery.getInt(i11);
                        columnIndex14 = i11;
                        int i13 = columnIndex15;
                        NetworkType networkTypeIntToNetworkType = i13 == -1 ? null : WorkTypeConverters.intToNetworkType(cursorQuery.getInt(i13));
                        columnIndex15 = i13;
                        int i14 = columnIndex16;
                        NetworkRequestCompat networkRequest$work_runtime_release = i14 == -1 ? null : WorkTypeConverters.toNetworkRequest$work_runtime_release(cursorQuery.getBlob(i14));
                        columnIndex16 = i14;
                        int i15 = columnIndex17;
                        if (i15 == -1) {
                            z = false;
                        } else {
                            z = cursorQuery.getInt(i15) != 0;
                        }
                        columnIndex17 = i15;
                        int i16 = columnIndex18;
                        if (i16 == -1) {
                            z2 = false;
                        } else {
                            z2 = cursorQuery.getInt(i16) != 0;
                        }
                        columnIndex18 = i16;
                        int i17 = columnIndex19;
                        if (i17 == -1) {
                            z3 = false;
                        } else {
                            z3 = cursorQuery.getInt(i17) != 0;
                        }
                        columnIndex19 = i17;
                        int i18 = columnIndex20;
                        if (i18 != -1 && cursorQuery.getInt(i18) != 0) {
                            z4 = true;
                        }
                        columnIndex20 = i18;
                        int i19 = columnIndex21;
                        boolean z5 = z4;
                        long j7 = i19 == -1 ? 0L : cursorQuery.getLong(i19);
                        columnIndex21 = i19;
                        int i20 = columnIndex22;
                        long j8 = i20 != -1 ? cursorQuery.getLong(i20) : 0L;
                        columnIndex22 = i20;
                        int i21 = columnIndex23;
                        columnIndex23 = i21;
                        arrayList.add(new WorkSpec.WorkInfoPojo(string3, stateIntToState, dataFromByteArray, j, j2, j3, new Constraints(networkRequest$work_runtime_release, networkTypeIntToNetworkType, z, z2, z3, z5, j7, j8, i21 == -1 ? null : WorkTypeConverters.byteArrayToSetOfTriggers(cursorQuery.getBlob(i21))), i5, backoffPolicyIntToBackoffPolicy, j4, j5, i7, i9, j6, i12, (ArrayList) map.get(cursorQuery.getString(columnIndex)), (ArrayList) map2.get(cursorQuery.getString(columnIndex))));
                    }
                    return arrayList;
                } finally {
                    cursorQuery.close();
                }
            }
        });
    }

    @Override // androidx.work.impl.model.RawWorkInfoDao
    public Flow<List<WorkSpec.WorkInfoPojo>> getWorkInfoPojosFlow(final SupportSQLiteQuery supportSQLiteQuery) {
        return CoroutinesRoom.createFlow(this.__db, false, new String[]{"WorkTag", "WorkProgress", "WorkSpec"}, new Callable() { // from class: androidx.work.impl.model.RawWorkInfoDao_Impl.2
            @Override // java.util.concurrent.Callable
            public List call() {
                boolean z;
                boolean z2;
                boolean z3;
                Cursor cursorQuery = DBUtil.query(RawWorkInfoDao_Impl.this.__db, supportSQLiteQuery, true, null);
                try {
                    int columnIndex = CursorUtil.getColumnIndex(cursorQuery, "id");
                    int columnIndex2 = CursorUtil.getColumnIndex(cursorQuery, "state");
                    int columnIndex3 = CursorUtil.getColumnIndex(cursorQuery, "output");
                    int columnIndex4 = CursorUtil.getColumnIndex(cursorQuery, "initial_delay");
                    int columnIndex5 = CursorUtil.getColumnIndex(cursorQuery, "interval_duration");
                    int columnIndex6 = CursorUtil.getColumnIndex(cursorQuery, "flex_duration");
                    int columnIndex7 = CursorUtil.getColumnIndex(cursorQuery, "run_attempt_count");
                    int columnIndex8 = CursorUtil.getColumnIndex(cursorQuery, "backoff_policy");
                    int columnIndex9 = CursorUtil.getColumnIndex(cursorQuery, "backoff_delay_duration");
                    int columnIndex10 = CursorUtil.getColumnIndex(cursorQuery, "last_enqueue_time");
                    int columnIndex11 = CursorUtil.getColumnIndex(cursorQuery, "period_count");
                    int columnIndex12 = CursorUtil.getColumnIndex(cursorQuery, "generation");
                    int columnIndex13 = CursorUtil.getColumnIndex(cursorQuery, "next_schedule_time_override");
                    int columnIndex14 = CursorUtil.getColumnIndex(cursorQuery, "stop_reason");
                    int columnIndex15 = CursorUtil.getColumnIndex(cursorQuery, "required_network_type");
                    int columnIndex16 = CursorUtil.getColumnIndex(cursorQuery, "required_network_request");
                    int columnIndex17 = CursorUtil.getColumnIndex(cursorQuery, "requires_charging");
                    int columnIndex18 = CursorUtil.getColumnIndex(cursorQuery, "requires_device_idle");
                    int columnIndex19 = CursorUtil.getColumnIndex(cursorQuery, "requires_battery_not_low");
                    int columnIndex20 = CursorUtil.getColumnIndex(cursorQuery, "requires_storage_not_low");
                    int columnIndex21 = CursorUtil.getColumnIndex(cursorQuery, "trigger_content_update_delay");
                    int columnIndex22 = CursorUtil.getColumnIndex(cursorQuery, "trigger_max_content_delay");
                    int columnIndex23 = CursorUtil.getColumnIndex(cursorQuery, "content_uri_triggers");
                    HashMap map = new HashMap();
                    int i = columnIndex13;
                    HashMap map2 = new HashMap();
                    while (cursorQuery.moveToNext()) {
                        int i2 = columnIndex12;
                        String string = cursorQuery.getString(columnIndex);
                        if (!map.containsKey(string)) {
                            map.put(string, new ArrayList());
                        }
                        String string2 = cursorQuery.getString(columnIndex);
                        if (!map2.containsKey(string2)) {
                            map2.put(string2, new ArrayList());
                        }
                        columnIndex12 = i2;
                        columnIndex11 = columnIndex11;
                    }
                    int i3 = columnIndex11;
                    int i4 = columnIndex12;
                    cursorQuery.moveToPosition(-1);
                    RawWorkInfoDao_Impl.this.__fetchRelationshipWorkTagAsjavaLangString(map);
                    RawWorkInfoDao_Impl.this.__fetchRelationshipWorkProgressAsandroidxWorkData(map2);
                    ArrayList arrayList = new ArrayList(cursorQuery.getCount());
                    while (cursorQuery.moveToNext()) {
                        String string3 = columnIndex == -1 ? null : cursorQuery.getString(columnIndex);
                        WorkInfo.State stateIntToState = columnIndex2 == -1 ? null : WorkTypeConverters.intToState(cursorQuery.getInt(columnIndex2));
                        Data dataFromByteArray = columnIndex3 == -1 ? null : Data.fromByteArray(cursorQuery.getBlob(columnIndex3));
                        long j = columnIndex4 == -1 ? 0L : cursorQuery.getLong(columnIndex4);
                        long j2 = columnIndex5 == -1 ? 0L : cursorQuery.getLong(columnIndex5);
                        long j3 = columnIndex6 == -1 ? 0L : cursorQuery.getLong(columnIndex6);
                        boolean z4 = false;
                        int i5 = columnIndex7 == -1 ? 0 : cursorQuery.getInt(columnIndex7);
                        BackoffPolicy backoffPolicyIntToBackoffPolicy = columnIndex8 == -1 ? null : WorkTypeConverters.intToBackoffPolicy(cursorQuery.getInt(columnIndex8));
                        long j4 = columnIndex9 == -1 ? 0L : cursorQuery.getLong(columnIndex9);
                        long j5 = columnIndex10 == -1 ? 0L : cursorQuery.getLong(columnIndex10);
                        int i6 = i3;
                        int i7 = i6 == -1 ? 0 : cursorQuery.getInt(i6);
                        i3 = i6;
                        int i8 = i4;
                        int i9 = i8 == -1 ? 0 : cursorQuery.getInt(i8);
                        i4 = i8;
                        int i10 = i;
                        long j6 = i10 == -1 ? 0L : cursorQuery.getLong(i10);
                        i = i10;
                        int i11 = columnIndex14;
                        int i12 = i11 == -1 ? 0 : cursorQuery.getInt(i11);
                        columnIndex14 = i11;
                        int i13 = columnIndex15;
                        NetworkType networkTypeIntToNetworkType = i13 == -1 ? null : WorkTypeConverters.intToNetworkType(cursorQuery.getInt(i13));
                        columnIndex15 = i13;
                        int i14 = columnIndex16;
                        NetworkRequestCompat networkRequest$work_runtime_release = i14 == -1 ? null : WorkTypeConverters.toNetworkRequest$work_runtime_release(cursorQuery.getBlob(i14));
                        columnIndex16 = i14;
                        int i15 = columnIndex17;
                        if (i15 == -1) {
                            z = false;
                        } else {
                            z = cursorQuery.getInt(i15) != 0;
                        }
                        columnIndex17 = i15;
                        int i16 = columnIndex18;
                        if (i16 == -1) {
                            z2 = false;
                        } else {
                            z2 = cursorQuery.getInt(i16) != 0;
                        }
                        columnIndex18 = i16;
                        int i17 = columnIndex19;
                        if (i17 == -1) {
                            z3 = false;
                        } else {
                            z3 = cursorQuery.getInt(i17) != 0;
                        }
                        columnIndex19 = i17;
                        int i18 = columnIndex20;
                        if (i18 != -1 && cursorQuery.getInt(i18) != 0) {
                            z4 = true;
                        }
                        columnIndex20 = i18;
                        int i19 = columnIndex21;
                        boolean z5 = z4;
                        long j7 = i19 == -1 ? 0L : cursorQuery.getLong(i19);
                        columnIndex21 = i19;
                        int i20 = columnIndex22;
                        long j8 = i20 != -1 ? cursorQuery.getLong(i20) : 0L;
                        columnIndex22 = i20;
                        int i21 = columnIndex23;
                        columnIndex23 = i21;
                        arrayList.add(new WorkSpec.WorkInfoPojo(string3, stateIntToState, dataFromByteArray, j, j2, j3, new Constraints(networkRequest$work_runtime_release, networkTypeIntToNetworkType, z, z2, z3, z5, j7, j8, i21 == -1 ? null : WorkTypeConverters.byteArrayToSetOfTriggers(cursorQuery.getBlob(i21))), i5, backoffPolicyIntToBackoffPolicy, j4, j5, i7, i9, j6, i12, (ArrayList) map.get(cursorQuery.getString(columnIndex)), (ArrayList) map2.get(cursorQuery.getString(columnIndex))));
                    }
                    return arrayList;
                } finally {
                    cursorQuery.close();
                }
            }
        });
    }

    public static List<Class<?>> getRequiredConverters() {
        return Collections.EMPTY_LIST;
    }

    /* JADX INFO: Access modifiers changed from: private */
    public void __fetchRelationshipWorkTagAsjavaLangString(HashMap<String, ArrayList<String>> map) {
        Set<String> setKeySet = map.keySet();
        if (setKeySet.isEmpty()) {
            return;
        }
        if (map.size() > 999) {
            RelationUtil.recursiveFetchHashMap(map, true, new Function1() { // from class: androidx.work.impl.model.RawWorkInfoDao_Impl$$ExternalSyntheticLambda0
                @Override // kotlin.jvm.functions.Function1
                public final Object invoke(Object obj) {
                    return RawWorkInfoDao_Impl.$r8$lambda$yc4IR39rbvYB0bwqH_trl8wxEEc(this.f$0, (HashMap) obj);
                }
            });
            return;
        }
        StringBuilder sbNewStringBuilder = StringUtil.newStringBuilder();
        sbNewStringBuilder.append("SELECT `tag`,`work_spec_id` FROM `WorkTag` WHERE `work_spec_id` IN (");
        int size = setKeySet.size();
        StringUtil.appendPlaceholders(sbNewStringBuilder, size);
        sbNewStringBuilder.append(")");
        RoomSQLiteQuery roomSQLiteQueryAcquire = RoomSQLiteQuery.acquire(sbNewStringBuilder.toString(), size);
        Iterator<String> it = setKeySet.iterator();
        int i = 1;
        while (it.hasNext()) {
            roomSQLiteQueryAcquire.bindString(i, it.next());
            i++;
        }
        Cursor cursorQuery = DBUtil.query(this.__db, roomSQLiteQueryAcquire, false, null);
        try {
            int columnIndex = CursorUtil.getColumnIndex(cursorQuery, "work_spec_id");
            if (columnIndex != -1) {
                while (cursorQuery.moveToNext()) {
                    ArrayList<String> arrayList = map.get(cursorQuery.getString(columnIndex));
                    if (arrayList != null) {
                        arrayList.add(cursorQuery.getString(0));
                    }
                }
                cursorQuery.close();
                return;
            }
            cursorQuery.close();
        } catch (Throwable th) {
            cursorQuery.close();
            throw th;
        }
    }

    public static /* synthetic */ Unit $r8$lambda$yc4IR39rbvYB0bwqH_trl8wxEEc(RawWorkInfoDao_Impl rawWorkInfoDao_Impl, HashMap map) {
        rawWorkInfoDao_Impl.__fetchRelationshipWorkTagAsjavaLangString(map);
        return Unit.INSTANCE;
    }

    /* JADX INFO: Access modifiers changed from: private */
    public void __fetchRelationshipWorkProgressAsandroidxWorkData(HashMap<String, ArrayList<Data>> map) {
        Set<String> setKeySet = map.keySet();
        if (setKeySet.isEmpty()) {
            return;
        }
        if (map.size() > 999) {
            RelationUtil.recursiveFetchHashMap(map, true, new Function1() { // from class: androidx.work.impl.model.RawWorkInfoDao_Impl$$ExternalSyntheticLambda1
                @Override // kotlin.jvm.functions.Function1
                public final Object invoke(Object obj) {
                    return RawWorkInfoDao_Impl.m157$r8$lambda$LiYrPQRjEmU_ODyJ23usNhUNyY(this.f$0, (HashMap) obj);
                }
            });
            return;
        }
        StringBuilder sbNewStringBuilder = StringUtil.newStringBuilder();
        sbNewStringBuilder.append("SELECT `progress`,`work_spec_id` FROM `WorkProgress` WHERE `work_spec_id` IN (");
        int size = setKeySet.size();
        StringUtil.appendPlaceholders(sbNewStringBuilder, size);
        sbNewStringBuilder.append(")");
        RoomSQLiteQuery roomSQLiteQueryAcquire = RoomSQLiteQuery.acquire(sbNewStringBuilder.toString(), size);
        Iterator<String> it = setKeySet.iterator();
        int i = 1;
        while (it.hasNext()) {
            roomSQLiteQueryAcquire.bindString(i, it.next());
            i++;
        }
        Cursor cursorQuery = DBUtil.query(this.__db, roomSQLiteQueryAcquire, false, null);
        try {
            int columnIndex = CursorUtil.getColumnIndex(cursorQuery, "work_spec_id");
            if (columnIndex != -1) {
                while (cursorQuery.moveToNext()) {
                    ArrayList<Data> arrayList = map.get(cursorQuery.getString(columnIndex));
                    if (arrayList != null) {
                        arrayList.add(Data.fromByteArray(cursorQuery.getBlob(0)));
                    }
                }
                cursorQuery.close();
                return;
            }
            cursorQuery.close();
        } catch (Throwable th) {
            cursorQuery.close();
            throw th;
        }
    }

    /* JADX INFO: renamed from: $r8$lambda$LiYrPQRjEmU_OD-yJ23usNhUNyY, reason: not valid java name */
    public static /* synthetic */ Unit m157$r8$lambda$LiYrPQRjEmU_ODyJ23usNhUNyY(RawWorkInfoDao_Impl rawWorkInfoDao_Impl, HashMap map) {
        rawWorkInfoDao_Impl.__fetchRelationshipWorkProgressAsandroidxWorkData(map);
        return Unit.INSTANCE;
    }
}
