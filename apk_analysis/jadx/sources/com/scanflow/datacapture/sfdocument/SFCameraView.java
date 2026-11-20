package com.scanflow.datacapture.sfdocument;

import android.R;
import android.app.Activity;
import android.content.Context;
import android.graphics.Color;
import android.graphics.Typeface;
import android.util.AttributeSet;
import android.widget.FrameLayout;
import android.widget.TextView;
import androidx.camera.view.PreviewView;
import com.scanflow.ui.ViewFinderView;
import com.scanflow.ui.ar.ArOverlayView;

/* JADX INFO: loaded from: classes3.dex */
public class SFCameraView extends FrameLayout {
    private ArOverlayView arOverlayView;
    private TextView copyright;
    private PreviewView previewView;
    private TextView textView;
    private ViewFinderView viewFinderView;

    public SFCameraView(Context context) {
        super(context, null);
    }

    public ArOverlayView getArOverlayView() {
        return this.arOverlayView;
    }

    public PreviewView getPreviewView() {
        return this.previewView;
    }

    public void setExpiredVisibility(final Boolean bool, final String str) {
        ((Activity) this.textView.getContext()).runOnUiThread(new Runnable() { // from class: com.scanflow.datacapture.sfdocument.SFCameraView.1
            @Override // java.lang.Runnable
            public void run() {
                TextView textView;
                int i;
                if (bool.booleanValue()) {
                    SFCameraView.this.textView.setText(str);
                    textView = SFCameraView.this.textView;
                    i = 0;
                } else {
                    textView = SFCameraView.this.textView;
                    i = 8;
                }
                textView.setVisibility(i);
            }
        });
    }

    public SFCameraView(Context context, AttributeSet attributeSet) {
        super(context, attributeSet, 0);
        this.previewView = new PreviewView(context, attributeSet);
        this.viewFinderView = new ViewFinderView(context, attributeSet);
        this.arOverlayView = new ArOverlayView(context, attributeSet);
        TextView textView = new TextView(context, attributeSet);
        this.textView = textView;
        textView.setGravity(17);
        this.textView.setTextSize(16.0f);
        this.textView.setPadding(20, 0, 20, 0);
        this.textView.setTextColor(Color.parseColor("#C0C0C0"));
        this.textView.setText("The Scanflow SDK licence validation failed. Your licence key has expired!");
        TextView textView2 = new TextView(context, attributeSet);
        this.copyright = textView2;
        textView2.setGravity(85);
        this.copyright.setTextSize(10.0f);
        this.copyright.setTextColor(Color.parseColor("#FFFFFF"));
        this.copyright.setPadding(0, 0, 20, 20);
        this.copyright.setTypeface(Typeface.create(Typeface.DEFAULT, 0));
        this.copyright.setText("SCANFLOW");
        FrameLayout.LayoutParams layoutParams = new FrameLayout.LayoutParams(-1, -1, 17);
        addView(this.previewView, layoutParams);
        addView(this.arOverlayView, layoutParams);
        addView(this.textView, layoutParams);
        addView(this.copyright, layoutParams);
        this.textView.setVisibility(8);
        this.previewView.setVisibility(0);
    }

    public SFCameraView(Context context, AttributeSet attributeSet, int i) {
        super(context, attributeSet, R.attr.alertDialogStyle);
    }
}
