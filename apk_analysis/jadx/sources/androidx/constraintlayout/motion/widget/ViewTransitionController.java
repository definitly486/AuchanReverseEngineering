package androidx.constraintlayout.motion.widget;

import android.graphics.Rect;
import android.util.Log;
import android.view.MotionEvent;
import android.view.View;
import androidx.constraintlayout.widget.ConstraintLayout;
import androidx.constraintlayout.widget.ConstraintSet;
import androidx.constraintlayout.widget.SharedValues;
import java.util.ArrayList;
import java.util.HashSet;

/* JADX INFO: loaded from: classes.dex */
public class ViewTransitionController {
    ArrayList mAnimations;
    private final MotionLayout mMotionLayout;
    private HashSet mRelatedViews;
    private ArrayList mViewTransitions = new ArrayList();
    private String mTAG = "ViewTransitionController";
    ArrayList mRemoveList = new ArrayList();

    public ViewTransitionController(MotionLayout motionLayout) {
        this.mMotionLayout = motionLayout;
    }

    public void add(ViewTransition viewTransition) {
        this.mViewTransitions.add(viewTransition);
        this.mRelatedViews = null;
        if (viewTransition.getStateTransition() == 4) {
            listenForSharedVariable(viewTransition, true);
        } else if (viewTransition.getStateTransition() == 5) {
            listenForSharedVariable(viewTransition, false);
        }
    }

    private void viewTransition(ViewTransition viewTransition, View... viewArr) {
        int currentState = this.mMotionLayout.getCurrentState();
        if (viewTransition.mViewTransitionMode == 2) {
            viewTransition.applyTransition(this, this.mMotionLayout, currentState, null, viewArr);
            return;
        }
        if (currentState == -1) {
            Log.w(this.mTAG, "No support for ViewTransition within transition yet. Currently: " + this.mMotionLayout.toString());
            return;
        }
        ConstraintSet constraintSet = this.mMotionLayout.getConstraintSet(currentState);
        if (constraintSet == null) {
            return;
        }
        viewTransition.applyTransition(this, this.mMotionLayout, currentState, constraintSet, viewArr);
    }

    void enableViewTransition(int i, boolean z) {
        ArrayList arrayList = this.mViewTransitions;
        int size = arrayList.size();
        int i2 = 0;
        while (i2 < size) {
            Object obj = arrayList.get(i2);
            i2++;
            ViewTransition viewTransition = (ViewTransition) obj;
            if (viewTransition.getId() == i) {
                viewTransition.setEnabled(z);
                return;
            }
        }
    }

    boolean isViewTransitionEnabled(int i) {
        ArrayList arrayList = this.mViewTransitions;
        int size = arrayList.size();
        int i2 = 0;
        while (i2 < size) {
            Object obj = arrayList.get(i2);
            i2++;
            ViewTransition viewTransition = (ViewTransition) obj;
            if (viewTransition.getId() == i) {
                return viewTransition.isEnabled();
            }
        }
        return false;
    }

    void viewTransition(int i, View... viewArr) {
        ArrayList arrayList = new ArrayList();
        ArrayList arrayList2 = this.mViewTransitions;
        int size = arrayList2.size();
        ViewTransition viewTransition = null;
        int i2 = 0;
        while (i2 < size) {
            Object obj = arrayList2.get(i2);
            i2++;
            ViewTransition viewTransition2 = (ViewTransition) obj;
            if (viewTransition2.getId() == i) {
                for (View view : viewArr) {
                    if (viewTransition2.checkTags(view)) {
                        arrayList.add(view);
                    }
                }
                if (!arrayList.isEmpty()) {
                    viewTransition(viewTransition2, (View[]) arrayList.toArray(new View[0]));
                    arrayList.clear();
                }
                viewTransition = viewTransition2;
            }
        }
        if (viewTransition == null) {
            Log.e(this.mTAG, " Could not find ViewTransition");
        }
    }

    void touchEvent(MotionEvent motionEvent) {
        int currentState = this.mMotionLayout.getCurrentState();
        if (currentState == -1) {
            return;
        }
        int i = 0;
        if (this.mRelatedViews == null) {
            this.mRelatedViews = new HashSet();
            ArrayList arrayList = this.mViewTransitions;
            int size = arrayList.size();
            int i2 = 0;
            while (i2 < size) {
                Object obj = arrayList.get(i2);
                i2++;
                ViewTransition viewTransition = (ViewTransition) obj;
                int childCount = this.mMotionLayout.getChildCount();
                for (int i3 = 0; i3 < childCount; i3++) {
                    View childAt = this.mMotionLayout.getChildAt(i3);
                    if (viewTransition.matchesView(childAt)) {
                        childAt.getId();
                        this.mRelatedViews.add(childAt);
                    }
                }
            }
        }
        float x = motionEvent.getX();
        float y = motionEvent.getY();
        Rect rect = new Rect();
        int action = motionEvent.getAction();
        ArrayList arrayList2 = this.mAnimations;
        if (arrayList2 != null && !arrayList2.isEmpty()) {
            ArrayList arrayList3 = this.mAnimations;
            int size2 = arrayList3.size();
            int i4 = 0;
            while (i4 < size2) {
                Object obj2 = arrayList3.get(i4);
                i4++;
                ((ViewTransition.Animate) obj2).reactTo(action, x, y);
            }
        }
        if (action == 0 || action == 1) {
            ConstraintSet constraintSet = this.mMotionLayout.getConstraintSet(currentState);
            ArrayList arrayList4 = this.mViewTransitions;
            int size3 = arrayList4.size();
            while (i < size3) {
                int i5 = i + 1;
                ViewTransition viewTransition2 = (ViewTransition) arrayList4.get(i);
                if (viewTransition2.supports(action)) {
                    for (View view : this.mRelatedViews) {
                        if (viewTransition2.matchesView(view)) {
                            view.getHitRect(rect);
                            if (rect.contains((int) x, (int) y)) {
                                viewTransition2.applyTransition(this, this.mMotionLayout, currentState, constraintSet, view);
                            }
                        }
                    }
                }
                i = i5;
            }
        }
    }

    void addAnimation(ViewTransition.Animate animate) {
        if (this.mAnimations == null) {
            this.mAnimations = new ArrayList();
        }
        this.mAnimations.add(animate);
    }

    void removeAnimation(ViewTransition.Animate animate) {
        this.mRemoveList.add(animate);
    }

    void animate() {
        ArrayList arrayList = this.mAnimations;
        if (arrayList == null) {
            return;
        }
        int size = arrayList.size();
        int i = 0;
        while (i < size) {
            Object obj = arrayList.get(i);
            i++;
            ((ViewTransition.Animate) obj).mutate();
        }
        this.mAnimations.removeAll(this.mRemoveList);
        this.mRemoveList.clear();
        if (this.mAnimations.isEmpty()) {
            this.mAnimations = null;
        }
    }

    void invalidate() {
        this.mMotionLayout.invalidate();
    }

    boolean applyViewTransition(int i, MotionController motionController) {
        ArrayList arrayList = this.mViewTransitions;
        int size = arrayList.size();
        int i2 = 0;
        while (i2 < size) {
            Object obj = arrayList.get(i2);
            i2++;
            ViewTransition viewTransition = (ViewTransition) obj;
            if (viewTransition.getId() == i) {
                viewTransition.mKeyFrames.addAllFrames(motionController);
                return true;
            }
        }
        return false;
    }

    private void listenForSharedVariable(final ViewTransition viewTransition, final boolean z) {
        final int sharedValueID = viewTransition.getSharedValueID();
        final int sharedValue = viewTransition.getSharedValue();
        ConstraintLayout.getSharedValues().addListener(viewTransition.getSharedValueID(), new SharedValues.SharedValuesListener() { // from class: androidx.constraintlayout.motion.widget.ViewTransitionController.1
            @Override // androidx.constraintlayout.widget.SharedValues.SharedValuesListener
            public void onNewValue(int i, int i2, int i3) {
                int sharedValueCurrent = viewTransition.getSharedValueCurrent();
                viewTransition.setSharedValueCurrent(i2);
                if (sharedValueID != i || sharedValueCurrent == i2) {
                    return;
                }
                int i4 = 0;
                if (z) {
                    if (sharedValue == i2) {
                        int childCount = ViewTransitionController.this.mMotionLayout.getChildCount();
                        while (i4 < childCount) {
                            View childAt = ViewTransitionController.this.mMotionLayout.getChildAt(i4);
                            if (viewTransition.matchesView(childAt)) {
                                int currentState = ViewTransitionController.this.mMotionLayout.getCurrentState();
                                ConstraintSet constraintSet = ViewTransitionController.this.mMotionLayout.getConstraintSet(currentState);
                                ViewTransition viewTransition2 = viewTransition;
                                ViewTransitionController viewTransitionController = ViewTransitionController.this;
                                viewTransition2.applyTransition(viewTransitionController, viewTransitionController.mMotionLayout, currentState, constraintSet, childAt);
                            }
                            i4++;
                        }
                        return;
                    }
                    return;
                }
                if (sharedValue != i2) {
                    int childCount2 = ViewTransitionController.this.mMotionLayout.getChildCount();
                    while (i4 < childCount2) {
                        View childAt2 = ViewTransitionController.this.mMotionLayout.getChildAt(i4);
                        if (viewTransition.matchesView(childAt2)) {
                            int currentState2 = ViewTransitionController.this.mMotionLayout.getCurrentState();
                            ConstraintSet constraintSet2 = ViewTransitionController.this.mMotionLayout.getConstraintSet(currentState2);
                            ViewTransition viewTransition3 = viewTransition;
                            ViewTransitionController viewTransitionController2 = ViewTransitionController.this;
                            viewTransition3.applyTransition(viewTransitionController2, viewTransitionController2.mMotionLayout, currentState2, constraintSet2, childAt2);
                        }
                        i4++;
                    }
                }
            }
        });
    }
}
