package com.scanflow.datacapture.model.session;

import android.content.Intent;
import androidx.activity.result.ActivityResultLauncher;
import com.scanflow.datacapture.config.DocumentCaptureConfig;
import java.io.File;
import java.util.List;

/* JADX INFO: loaded from: classes3.dex */
public abstract class SFDocumentReader {
    public abstract List<File> getCapturedDocumentList();

    public abstract SFDocumentReader setOnActivityResultLauncher(ActivityResultLauncher<Intent> activityResultLauncher);

    public abstract SFDocumentReader startDocumentCapture(DocumentCaptureConfig documentCaptureConfig);
}
