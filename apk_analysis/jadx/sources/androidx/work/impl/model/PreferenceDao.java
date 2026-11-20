package androidx.work.impl.model;

import androidx.lifecycle.LiveData;

/* JADX INFO: compiled from: PreferenceDao.kt */
/* JADX INFO: loaded from: classes.dex */
public interface PreferenceDao {
    Long getLongValue(String str);

    LiveData<Long> getObservableLongValue(String str);

    void insertPreference(Preference preference);
}
